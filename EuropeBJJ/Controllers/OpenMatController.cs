using EuropeBJJ.Data;
using EuropeBJJ.Data.Models;
using EuropeBJJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.Claims;

namespace EuropeBJJ.Controllers
{
    using static EuropeBJJ.Constants.ModelConstants;
    public class OpenMatController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public OpenMatController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await dbContext.Events.OfType<OpenMat>().Where(e => e.IsRemoved == false).Select(e => new OpenMatViewModel()
            {
                Id = e.Id,
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Date = e.Date.ToString(DateFormat),
                Location = e.Location,
                IsPinned = e.EventAccounts.Any(ea => ea.AccountId == currentUserId)
            }).ToListAsync();


            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddOpenMatViewModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddOpenMatViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            bool validAddedOn = DateTime.TryParseExact(model.Date, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

            if (!validAddedOn)
            {
                ModelState.AddModelError(nameof(model.Date), "Invalid date format");
                return this.View(model);
            }



            OpenMat openmat = new OpenMat
            {
                Name = model.Name,
                Country = model.Country,
                City = model.City,
                Location = model.Location,
                Date = date,
                Organiser = model.Organiser,
                MembersPrice = model.MembersPrice ?? 0m,
                NonMembersPrice = model.NonMembersPrice ?? 0m,
                Image = model.Image,
                Description = model.Description,
                AccountId = GetCurrentUserId() ?? string.Empty,
                IsRemoved = false
            };

            await dbContext.Events.AddAsync(openmat);
            await dbContext.SaveChangesAsync();

            return this.RedirectToAction("Index", "Home");
        }
    }
}

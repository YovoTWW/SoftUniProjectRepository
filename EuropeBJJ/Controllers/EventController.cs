using EuropeBJJ.Data;
using EuropeBJJ.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static EuropeBJJ.Constants.ModelConstants;
using EuropeBJJ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using System.Globalization;

namespace EuropeBJJ.Controllers
{
    public class EventController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public EventController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }


        [HttpGet]
        public async Task<IActionResult> TournamentIndex()
        {
            var model = await dbContext.Events.OfType<Tournament>().Select(e => new TournamentViewModel()
            {
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Link = e.Link,
            }).ToListAsync();

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> OpenMatIndex()
        {                  
                var model = await dbContext.Events.OfType<OpenMat>().Select(e => new OpenMatViewModel()
                {
                    Image = e.Image,
                    Name = e.Name,
                    Country = e.Country,
                    City = e.City,
                    Date = e.Date.ToString(DateFormat),
                    Location = e.Location
                }).ToListAsync();

                return this.View(model);                      
        }

        [HttpGet]
        public async Task<IActionResult> SeminarIndex()
        {
            var model = await dbContext.Events.OfType<Seminar>().Select(e => new SeminarViewModel()
            {
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Date = e.Date.ToString(DateFormat),
                Location = e.Location,
                Teacher = e.Teacher
            }).ToListAsync();

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddOpenMat()
        {
            var model = new AddOpenMatViewModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddOpenMat(AddOpenMatViewModel model)
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
                MembersPrice = model.MembersPrice,
                NonMembersPrice = model.NonMembersPrice,
                Image = model.Image,
                Description = model.Description,
                AccountId = GetCurrentUserId() ?? string.Empty,
                IsRemoved = false
            };

            await dbContext.Events.AddAsync(openmat);
            await dbContext.SaveChangesAsync();

            return this.RedirectToAction("Index","Home");
        }
    }
}

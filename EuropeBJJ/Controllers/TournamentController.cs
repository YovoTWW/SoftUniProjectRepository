using EuropeBJJ.Constants;
using EuropeBJJ.Data;
using EuropeBJJ.Data.Models;
using EuropeBJJ.Models;
using EuropeBJJ.Models.Event.Tournament;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.Claims;


namespace EuropeBJJ.Controllers
{
    using static EuropeBJJ.Constants.ModelConstants;
    public class TournamentController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public TournamentController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }

        private string? GetCurrentUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchTextName , string filterCountry)
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            ViewData["SearchTextName"] = searchTextName;
            ViewData["FilterCountry"] = filterCountry;
            ViewData["Countries"] = CountriesList.ListOfCountries;

            var model = await dbContext.Events.OfType<Tournament>().Where(e => e.IsRemoved == false).Select(e => new TournamentViewModel()
            {
                Id = e.Id,
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Link = e.Link,
                IsPinned = e.EventAccounts.Any(ea => ea.AccountId == currentUserId)
            }).ToListAsync();

            if (!string.IsNullOrWhiteSpace(searchTextName))
            {
                model = model.Where(e => e.Name.Contains(searchTextName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(filterCountry))
            {
                model = model.Where(e => e.Country == filterCountry).ToList();
            }

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddTournamentViewModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddTournamentViewModel model)
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



            Tournament tournament = new Tournament
            {
                Name = model.Name,
                Country = model.Country,
                City = model.City,
                Date = date,
                Image = model.Image,
                Link = model.Link,
                AccountId = GetCurrentUserId() ?? string.Empty,
                IsRemoved = false
            };

            await dbContext.Events.AddAsync(tournament);
            await dbContext.SaveChangesAsync();

            return this.RedirectToAction("Index", "Home");
        }
    }
}

using EuropeBJJ.Data;
using EuropeBJJ.Data.Models;
using EuropeBJJ.Models.Event;
using EuropeBJJ.Models.Profile;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Claims;

namespace EuropeBJJ.Controllers
{
    public class ProfileController : Controller
    {

        private readonly ApplicationDbContext dbContext;

        public ProfileController(ApplicationDbContext context)
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

            var model = await dbContext.Profiles.Select(p => new ProfileViewModel()
            {
                ProfileId = p.ProfileId,
                FullName = p.FullName,
                Picture = p.Picture            
            }).ToListAsync();

            return this.View(model);
        }

            [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AddProfileViewModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddProfileViewModel model)
        {

            string currentUserId = GetCurrentUserId() ?? string.Empty;

            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }



            Profile profile = new Profile
            {
               FullName = model.FullName,
               Age = model.Age,
               Belt = model.Belt,
               AboutText = model.AboutText,
               Country = model.Country,
               AccountId = currentUserId
            };

            await dbContext.Profiles.AddAsync(profile);
            await dbContext.SaveChangesAsync();

            return this.RedirectToAction("Index", "Profile");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {

            var model = await dbContext.Profiles.Where(p => p.ProfileId == id).AsNoTracking().Select(p => new ProfileDetailedViewModel
            {
               ProfileId = p.ProfileId,
               FullName = p.FullName,
               Age = p.Age,
               Belt = p.Belt,
               AboutText = p.AboutText,
               Country = p.Country,
               Creator = p.Account.UserName ?? string.Empty
            }).FirstOrDefaultAsync();

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> MyProfile()
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await dbContext.Profiles.Where(p => p.AccountId==currentUserId).AsNoTracking().Select(p => new ProfileDetailedViewModel
            {
                ProfileId = p.ProfileId,
                FullName = p.FullName,
                Age = p.Age,
                Belt = p.Belt,
                AboutText = p.AboutText,
                Country = p.Country,
                Creator = p.Account.UserName ?? string.Empty
            }).FirstOrDefaultAsync();

            return this.View(model);
        }

    }
}

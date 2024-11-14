using EuropeBJJ.Data;
using EuropeBJJ.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static EuropeBJJ.Constants.ModelConstants;
using EuropeBJJ.Models;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Index()
        {
            var model = await dbContext.Events.OfType<Tournament>().Select(e => new TournamentViewModel()
            {
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Link = e.Link
            }).ToListAsync();

            return this.View(model);
        }


    }
}

using EuropeBJJ.Constants;
using EuropeBJJ.Data;
using EuropeBJJ.Data.Models;
using EuropeBJJ.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EuropeBJJ.Controllers
{
    public class SponsorController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SponsorController(ApplicationDbContext context)
        {
            this.dbContext = context;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var model = await dbContext.Sponsors.Where(s => s.IsRemoved == false).Select(s => new SponsorViewModel()
            {
                Name = s.Name,
                Image = s.Image,
                Link = s.Link
            }).ToListAsync();

            return this.View(model);
        }


    }
}

using EuropeBJJ.Constants;
using EuropeBJJ.Data;
using EuropeBJJ.Data.Models;
using EuropeBJJ.Models.Sponsor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Globalization;
using System.Security.Claims;

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
                Id = s.Id,
                Name = s.Name,
                Image = s.Image,
                Link = s.Link
            }).ToListAsync();

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new SponsorViewModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SponsorViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            

            Sponsor sponsor = new Sponsor
            {
                Name = model.Name,
                Image = model.Image,
                Link = model.Link
            };

            await dbContext.Sponsors.AddAsync(sponsor);
            await dbContext.SaveChangesAsync();

            return this.RedirectToAction("Index", "Sponsor");
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var model = await dbContext.Sponsors.Where(s => s.Id == id).Where(s => s.IsRemoved == false).AsNoTracking().Select(s => new SponsorViewModel
            {
                Name= s.Name,
                Link = s.Link,
                Image = s.Image
            }).FirstOrDefaultAsync();

            return this.View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(SponsorViewModel model, int id)
        {
            if (!this.ModelState.IsValid)
            {
                throw new ArgumentException("Invalid Model State");
            }


            Sponsor? entity = await dbContext.Sponsors.FindAsync(id);

            if (entity == null || entity.IsRemoved)
            {
                throw new ArgumentException("Invalid id");
            }
           

            entity.Name = model.Name;           
            entity.Link = model.Link;
            entity.Image = model.Image;
            
            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Sponsor");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await dbContext.Sponsors.Where(s => s.Id == id).Where(s => s.IsRemoved == false).AsNoTracking().Select(e => new SponsorViewModel
            {
                Id = e.Id,
                Name = e.Name,
            }).FirstOrDefaultAsync();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SponsorViewModel model)
        {
            Sponsor? Sponsor = await dbContext.Sponsors.Where(s => s.Id == model.Id).Where(s => s.IsRemoved == false).FirstOrDefaultAsync();

            if (Sponsor != null)
            {

                Sponsor.IsRemoved = true;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Sponsor");
        }

    }
}

using EuropeBJJ.Data;
using EuropeBJJ.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static EuropeBJJ.Constants.ModelConstants;
using EuropeBJJ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using System.Globalization;
using Microsoft.IdentityModel.Abstractions;
using Microsoft.Identity.Client;

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
        public async Task<IActionResult> Pinned()
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await dbContext.Events.Where(e => e.IsRemoved == false).Where(e => e.EventAccounts.Any(ea => ea.AccountId == currentUserId))
                .Select(e => new EventGeneralisedViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Country = e.Country,
                    City = e.City,
                    Date = e.Date.ToString(DateFormat),
                    Image = e.Image,
                    EventType = e.Discriminator
                }).AsNoTracking().ToListAsync();

            return this.View(model);
        }


        [HttpPost]
        public async Task<IActionResult> AddToPinned(int id)
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;
            Event? entity = await dbContext.Events.Where(e => e.Id == id).Include(e => e.EventAccounts).FirstOrDefaultAsync();

            if (entity == null || entity.IsRemoved)
            {
                throw new ArgumentException("Invalid id");
            }

            if (entity.EventAccounts.Any(ea=> ea.AccountId == currentUserId))
            {
                return this.RedirectToAction("Index","Home");
            }

            entity.EventAccounts.Add(new EventAccount()
            {
                AccountId = currentUserId,
                EventId = entity.Id
            });

            await dbContext.SaveChangesAsync();

            return this.RedirectToAction("Pinned");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromPinned(int id)
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            Event? entity = await dbContext.Events.Where(e => e.Id == id).Include(e => e.EventAccounts).FirstOrDefaultAsync();

            EventAccount? eventAccount = entity.EventAccounts.FirstOrDefault(ea => ea.AccountId == currentUserId);

            if (entity == null || entity.IsRemoved)
            {
                throw new ArgumentException("Invalid id");
            }

            if (eventAccount != null)
            {
                entity.EventAccounts.Remove(eventAccount);

                await dbContext.SaveChangesAsync();
            }

            return this.RedirectToAction("Pinned");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await dbContext.Events.Where(e => e.Id == id).Where(e => e.IsRemoved == false).AsNoTracking().Select(e => new EventDetailsViewModel
            {
                Id = e.Id,
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Date = e.Date.ToString(DateFormat),
                Description = e.Description ?? string.Empty,
                Location = e.Location ?? string.Empty,
                Organiser = e.Organiser ?? string.Empty,
                MembersPrice = e.MembersPrice ?? 0m,
                NonMembersPrice = e.NonMembersPrice ?? 0m,
                Teacher = e.Teacher ?? string.Empty,
                IsPinned = e.EventAccounts.Any(ea => ea.AccountId == currentUserId),
                Creator = e.Account.UserName ?? string.Empty,
                Link = e.Link ?? string.Empty,
                EventType = e.Discriminator
            }).FirstOrDefaultAsync();

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            
            var model = await dbContext.Events.Where(e => e.Id == id).Where(e => e.IsRemoved == false).AsNoTracking().Select(e => new EventEditViewModel
            {                
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Date = e.Date.ToString(DateFormat),
                Description = e.Description ?? string.Empty,
                Location = e.Location ?? string.Empty,
                Organiser = e.Organiser ?? string.Empty,
                MembersPrice = e.MembersPrice ?? 0m,
                NonMembersPrice = e.NonMembersPrice ?? 0m,
                Teacher = e.Teacher ?? string.Empty,                
                Creator = e.Account.UserName ?? string.Empty,
                Link = e.Link ?? string.Empty ,
                EventType = e.Discriminator,
                AccountId = GetCurrentUserId() ?? string.Empty
        }).FirstOrDefaultAsync();

            return this.View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EventEditViewModel model, int id)
        {
            if (!this.ModelState.IsValid)
            {
                throw new ArgumentException("Invalid Model State");
            }

            bool validDate= DateTime.TryParseExact(model.Date, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

            if (!validDate)
            {
                ModelState.AddModelError(nameof(model.Date), "Invalid date format");               
                return this.View(model);
            }

            

            Event? entity = await dbContext.Events.FindAsync(id);

            if (entity == null || entity.IsRemoved)
            {
                throw new ArgumentException("Invalid id");
            }
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            if (entity.AccountId != currentUserId)
            {
                return RedirectToAction("Index","Home");
            }

            entity.Name = model.Name;
            entity.Country = model.Country;
            entity.City = model.City;
            entity.Date = date;
            entity.AccountId = GetCurrentUserId() ?? string.Empty;

            if (model.EventType == "Tournament")
            {
                entity.Link = model.Link;
            }

            if(model.EventType=="OpenMat" || model.EventType=="Seminar")
            {
                entity.Organiser = model.Organiser;
                entity.MembersPrice = model.MembersPrice;
                entity.NonMembersPrice = model.NonMembersPrice;
                entity.Description = model.Description;

                if(model.EventType=="Seminar")
                {
                    entity.Teacher = model.Teacher;
                }
            }

            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var model = await dbContext.Events.Where(e => e.Id == id).Where(e => e.IsRemoved == false).AsNoTracking().Select(e => new DeleteViewModel
            {
                Id = e.Id,
                Name = e.Name,
                Account = e.Account.UserName ?? string.Empty,
                AccountId = e.AccountId
            }).FirstOrDefaultAsync();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteViewModel model)
        {
            Event? Event = await dbContext.Events.Where(e => e.Id == model.Id).Where(e => e.IsRemoved == false).FirstOrDefaultAsync();

            if (Event != null)
            {

                Event.IsRemoved = true;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index","Home");
        }
    }


}

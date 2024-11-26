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
                Id = e.Id,
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
            var model =  await dbContext.Events.OfType<OpenMat>().Select(e => new OpenMatViewModel()      
        {
                Id = e.Id,
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
                Id = e.Id,
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

        [HttpGet]
        public async Task<IActionResult> AddSeminar()
        {
            var model = new AddSeminarViewModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddSeminar(AddSeminarViewModel model)
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



            Seminar seminar = new Seminar
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
                Teacher = model.Teacher,
                AccountId = GetCurrentUserId() ?? string.Empty,
                IsRemoved = false
            };

            await dbContext.Events.AddAsync(seminar);
            await dbContext.SaveChangesAsync();

            return this.RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> AddTournament()
        {
            var model = new AddTournamentViewModel();
            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddTournament(AddTournamentViewModel model)
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



        [HttpGet]
        public async Task<IActionResult> Pinned()
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await dbContext.Events.Where(e => e.IsRemoved == false).Where(e => e.EventAccounts.Any(ea => ea.AccountId == currentUserId))
                .Select(e => new EventGeneralisedViewModel()
                {
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
    }
}

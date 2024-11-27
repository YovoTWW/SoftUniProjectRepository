﻿using EuropeBJJ.Data;
using EuropeBJJ.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static EuropeBJJ.Constants.ModelConstants;
using EuropeBJJ.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;
using System.Globalization;
using Microsoft.IdentityModel.Abstractions;

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
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await dbContext.Events.OfType<Tournament>().Select(e => new TournamentViewModel()
            {
                Id = e.Id,
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Link = e.Link,
                IsPinned = e.EventAccounts.Any(ea=>ea.AccountId==currentUserId)
            }).ToListAsync();

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> OpenMatIndex()
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model =  await dbContext.Events.OfType<OpenMat>().Select(e => new OpenMatViewModel()      
            {
                Id = e.Id,
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Date = e.Date.ToString(DateFormat),
                Location = e.Location ,
                IsPinned = e.EventAccounts.Any(ea => ea.AccountId == currentUserId)
            }).ToListAsync();

          

            return this.View(model);                      
        }

        [HttpGet]
        public async Task<IActionResult> SeminarIndex()
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await dbContext.Events.OfType<Seminar>().Select(e => new SeminarViewModel()
            {
                Id = e.Id,
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Date = e.Date.ToString(DateFormat),
                Location = e.Location,
                Teacher = e.Teacher,
                IsPinned = e.EventAccounts.Any(ea => ea.AccountId == currentUserId)
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
                MembersPrice = model.MembersPrice ?? 0m,
                NonMembersPrice = model.NonMembersPrice ?? 0m,
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
                MembersPrice = model.MembersPrice ?? 0m,
                NonMembersPrice = model.NonMembersPrice ?? 0m,
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
        public async Task<IActionResult> TournamentDetails(int id)
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await dbContext.Events.Where(e => e.Id == id).Where(e => e.IsRemoved == false).AsNoTracking().Select(e => new TournamentViewModel
            {            
                Id = e.Id,
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Link = e.Link,
                IsPinned = e.EventAccounts.Any(ea => ea.AccountId == currentUserId),
                Date = e.Date.ToString(DateFormat),
                Creator = e.Account.UserName ?? string.Empty
            }).FirstOrDefaultAsync();


            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> OpenMatDetails(int id)
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await dbContext.Events.Where(e => e.Id == id).Where(e => e.IsRemoved == false).AsNoTracking().Select(e => new OpenMatDetailsViewModel
            {
                Id = e.Id,
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Date = e.Date.ToString(DateFormat),
                Description = e.Description,
                Location = e.Location,
                Organiser = e.Organiser,
                MembersPrice = e.MembersPrice ?? 0m,
                NonMembersPrice = e.NonMembersPrice ?? 0m,
                IsPinned = e.EventAccounts.Any(ea => ea.AccountId == currentUserId),
                Creator = e.Account.UserName ?? string.Empty
            }).FirstOrDefaultAsync();

            return this.View(model);
        }


        [HttpGet]
        public async Task<IActionResult> SeminarDetails(int id)
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await dbContext.Events.Where(e => e.Id == id).Where(e => e.IsRemoved == false).AsNoTracking().Select(e => new SeminarDetailsViewModel
            {
                Id = e.Id,
                Image = e.Image,
                Name = e.Name,
                Country = e.Country,
                City = e.City,
                Date = e.Date.ToString(DateFormat),
                Description = e.Description,
                Location = e.Location,
                Organiser = e.Organiser,
                MembersPrice = e.MembersPrice ?? 0m,
                NonMembersPrice = e.NonMembersPrice ?? 0m,
                Teacher = e.Teacher,
                IsPinned = e.EventAccounts.Any(ea => ea.AccountId == currentUserId),
                Creator = e.Account.UserName ?? string.Empty
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

    }


}

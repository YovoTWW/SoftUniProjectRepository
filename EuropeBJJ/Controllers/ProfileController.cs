﻿using EuropeBJJ.Data;
using EuropeBJJ.Data.Models;
using EuropeBJJ.Models.Event;
using EuropeBJJ.Models.Profile;
using EuropeBJJ.Models.Sponsor;
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
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = new AddProfileViewModel();

            Profile profile = await dbContext.Profiles.FirstOrDefaultAsync(p=>p.AccountId== currentUserId);

            if(profile == null)
            {
                model.Exists = false;
            }
            else
            {
                model.Exists = true;
            }

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
               Team = model.Team,
               AccountId = currentUserId,
               Picture = model.Picture
            };

            await dbContext.Profiles.AddAsync(profile);
            await dbContext.SaveChangesAsync();

            return this.RedirectToAction("MyProfile", "Profile");
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
                Team = p.Team,
                Creator = p.Account.UserName ?? string.Empty
            }).FirstOrDefaultAsync();

            return this.View(model);
        }



        [HttpGet]
        public async Task<IActionResult> Edit()
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await dbContext.Profiles.Where(p => p.AccountId==currentUserId).AsNoTracking().Select(p => new AddProfileViewModel
            {
                FullName = p.FullName,
                Age = p.Age,
                Belt = p.Belt,
                AboutText = p.AboutText,
                Country = p.Country,
                Team = p.Team,
                Picture = p.Picture,               
            }).FirstOrDefaultAsync();

            
            return this.View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(AddProfileViewModel model)
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            if (!this.ModelState.IsValid)
            {
                throw new ArgumentException("Invalid Model State");
            }


            Profile? entity = await dbContext.Profiles.FirstOrDefaultAsync(p => p.AccountId == currentUserId);

            if (entity == null )
            {
                throw new ArgumentException("Profile is not Set Up");
            }


            entity.FullName = model.FullName;
            entity.Team = model.Team;
            entity.Picture = model.Picture;
            entity.Belt = model.Belt;
            entity.Age = model.Age;
            entity.Country = model.Country;
            entity.AboutText = model.AboutText;

            await this.dbContext.SaveChangesAsync();

            return RedirectToAction("MyProfile", "Profile");
        }

        [HttpGet]
        public async Task<IActionResult> Delete()
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            var model = await dbContext.Profiles.Where(p => p.AccountId==currentUserId).AsNoTracking().Select(e => new ProfileViewModel
            {
                FullName = e.FullName
            }).FirstOrDefaultAsync();

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ProfileViewModel model)
        {
            string currentUserId = GetCurrentUserId() ?? string.Empty;

            Profile? Profile = await dbContext.Profiles.Where(p=>p.AccountId==currentUserId).FirstOrDefaultAsync();

            if (Profile != null)
            {

                dbContext.Profiles.Remove(Profile);

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Home");
        }
    }



}

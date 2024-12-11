using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using EuropeBJJ.Data.Models;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EuropeBJJ.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);

         builder.Entity<Event>()
        .HasDiscriminator<string>("Discriminator")
        .HasValue<Tournament>("Tournament")
        .HasValue<OpenMat>("OpenMat")
        .HasValue<Seminar>("Seminar");
        
        builder.Entity<Tournament>().
                HasData(
                new Tournament {Id=1, Name = "ADCC Balkans Open", Country = "Bulgaria", City = "Sofia", Date = new DateTime(2024,12,16), Link = "https://adcombat.com/adcc-events/adcc-bulgaria-balkans-open-2024/", Image = "https://smoothcomp.com/pictures/t/4582681-vxth/adcc-balkan-open-championships-2024.png" },
                new Tournament { Id=2,Name = "AGF 2024 BULGARIAN JIU JITSU CHAMPIONSHIPS", Country = "Bulgaria", City = "Sofia",  Date = new DateTime(2024, 12, 17), Link = "https://agf.smoothcomp.com/en/event/19393", Image = "https://smoothcomp.com/pictures/t/4794848-q7z/2024-bulgarian-jiu-jitsu-championship.jpg" },
                new Tournament { Id=3,Name = "AJP TOUR BULGARIA NATIONAL JIU-JITSU CHAMPIONSHIP 2024 - GI & NO-GI", Country = "Bulgaria", City = "Sofia", Date = new DateTime(2024, 12, 21), Link = "https://ajptour.com/en/event/1104", Image = "https://ajptour.com/build/webpack/img/ajp/fallback.a01f59147724b9274315365bd75f5b21.jpg" },
                new Tournament { Id=4,Name = "Lisbon International Open IBJJF Jiu-Jitsu Championship 2024", Country = "Portugal", City = "Lisbon", Date = new DateTime(2024, 12, 18), Link = "https://ibjjf.com/events/lisbon-international-open-ibjjf-jiu-jitsu-championship-2024", Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQCa0fogWrglVFNDHt83Z91Ik795AN2Pd31eA&s" },
                new Tournament { Id = 14, Name = "SJJIFBF Sofia Winter Open 2025 Gi & No-Gi ", Country = "Bulgaria", City = "Sofia", Date = new DateTime(2024, 12, 16), Link = "https://sjjif.smoothcomp.com/en/event/20819", Image = "https://smoothcomp.com/pictures/t/5170482-d6y7/sjjifbf-sofia-winter-open-2025-gi-no-gi.jpg" });

            builder.Entity<Sponsor>().
                    HasData(
                    new Sponsor { Id = 1, Name = "Born Winner", Image = "/img/BornWinner.jpg", Link = "https://www.bornwinner.bg" },
                    new Sponsor { Id = 2, Name = "Ground Game", Image = "/img/groundgame.jpg", Link = "https://groundgame.com/" },
                    new Sponsor { Id = 3, Name = "FUJI Mats", Image = "/img/FUJI_Mats.jpg", Link = "https://fujimats.com/" }
                    );
                }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventAccount> EventsAccounts { get; set; }

        public DbSet<Sponsor> Sponsors { get; set;}

        public DbSet<Profile> Profiles { get; set; }

        public DbSet<EventProfile> EventsProfiles { get; set; }

    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using EuropeBJJ.Data.Models;
using System.Reflection.Emit;

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
                new Tournament {Id=1, Name = "ADCC Balkans Open", Country = "Bulgaria", City = "Sofia", Date = DateTime.Now, Link = "https://smoothcomp.com/en/event/17862", Image = "https://smoothcomp.com/pictures/t/4582681-vxth/adcc-balkan-open-championships-2024.png" },
                new Tournament { Id=2,Name = "AGF 2024 BULGARIAN JIU JITSU CHAMPIONSHIPS", Country = "Bulgaria", City = "Sofia", Date = DateTime.Now, Link = "https://agf.smoothcomp.com/en/event/19393", Image = "https://smoothcomp.com/pictures/t/4794848-q7z/2024-bulgarian-jiu-jitsu-championship.jpg" },
                new Tournament { Id=3,Name = "AJP TOUR BULGARIA NATIONAL JIU-JITSU CHAMPIONSHIP 2024 - GI & NO-GI", Country = "Bulgaria", City = "Sofia", Date = DateTime.Now, Link = "https://ajptour.com/en/event/1104", Image = "https://ajptour.com/build/webpack/img/ajp/fallback.a01f59147724b9274315365bd75f5b21.jpg" },
                new Tournament { Id=4,Name = "Lisbon International Open IBJJF Jiu-Jitsu Championship 2024", Country = "Portugal", City = "Lisbon", Date = DateTime.Now, Link = "https://ibjjf.com/events/lisbon-international-open-ibjjf-jiu-jitsu-championship-2024", Image = "https://ibjjf.com/rails/active_storage/blobs/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBam9hIiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--17bf4a00266e5788a79c44d985d0b399c0ab0bec/lisbon-2024-logo-website-white%20(1).png" });
        }

        public DbSet<Event> Events { get; set; }

        public DbSet<EventAccount> EventsAccounts { get; set; }

    }
}

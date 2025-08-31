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

        builder.Entity<OpenMat>().HasData(
        new OpenMat
        {
            Id = 7,
            Name = "Annual BJJ Open Mat",
            Country = "Bulgaria",
            City = "Varna",
            Date = new DateTime(2024, 12, 20),
            Image = "https://regents.bg/wp-content/uploads/2023/07/varna1.jpg",
            Description = "This is the annual BJJ Open Mat",
            IsRemoved = false,
            Location = "Mall Varna",
            MembersPrice = 5.00m,
            NonMembersPrice = 10.00m,
            Organiser = "Bruno Bastos BJJ",
            Teacher = null
        },
        new OpenMat
        {
            Id = 8,
            Name = "Annual BJJ Open Mat 2",
            Country = "Bulgaria",
            City = "Varna",
            Date = new DateTime(2024, 12, 21),
            Image = "https://static.pochivka.bg/sights.bgstay.com/images/02/2263/54cf52c61c042.jpg",
            Description = "The 2nd Annual BJJ Open Mat",
            IsRemoved = false,
            Location = "Mall Varna",
            MembersPrice = 5.00m,
            NonMembersPrice = 10.00m,
            Organiser = "Bruno Bastos BJJ",
            Teacher = null
        },
        new OpenMat
        {
            Id = 11,
            Name = "Burgas Beach Open Mat",
            Country = "Bulgaria",
            City = "Burgas",
            Date = new DateTime(2025, 7, 21),
            Image = "https://www.cestee.bg/images/79/47/167947-920w.webp",
            Description = "Open Mat on the beach of Burgas for all BJJ enthusiasts. There is no entry fee , all are welcome.",
            IsRemoved = false,
            Location = "Бургаски плаж",
            MembersPrice = 0.00m,
            NonMembersPrice = 0.00m,
            Organiser = "GFTeam",
            Teacher = null
        }
    );

            builder.Entity<Seminar>().HasData(
                new Seminar
                {
                    Id = 9,
                    Name = "Craig Jones Burgas Summer Seminar",
                    Country = "Bulgaria",
                    City = "Burgas",
                    Date = new DateTime(2025, 8, 16),
                    Image = "https://www.bjjee.com/wp-content/uploads/2023/09/Craig-Jones.jpg",
                    Description = "Australian BJJ Black Belt and world class competitor Craig Jones is coming to Bulgaria to teach a seminar in Burgas for the Summer . Stay Tuned.",
                    IsRemoved = false,
                    Location = "GFTeam Burgas (BJJ Academy)",
                    MembersPrice = 56.00m,
                    NonMembersPrice = 66.00m,
                    Organiser = "GFTeam",
                    Teacher = "Craig Jones"
                },
                new Seminar
                {
                    Id = 23,
                    Name = "Gordon Ryan Seminar",
                    Country = "Bulgaria",
                    City = "Sofia",
                    Date = new DateTime(2024, 12, 25),
                    Image = "https://external-preview.redd.it/vAE1_iqx_SyojYytsJ1kpb-Ei5KJ3r2uavwah5LqiQc.jpg?auto=webp&s=a65a6f84e6ff926dfc7e87e74d57e3e453de9211",
                    Description = "Gordon Ryan is coming to Sofia Bulgaria to host a Seminar .",
                    IsRemoved = false,
                    Location = "Arena Sofia",
                    MembersPrice = 65.00m,
                    NonMembersPrice = 75.00m,
                    Organiser = "New Wave",
                    Teacher = "Gordon Ryan"
                },
                new Seminar
                {
                    Id = 31,
                    Name = "Lachlan Giles Varna Seminar",
                    Country = "Bulgaria",
                    City = "Varna",
                    Date = new DateTime(2024, 12, 16),
                    Image = "https://optimg.submeta.io/uploads/41d535fe-44f0-4da2-b16b-9653896fff8e_1636087068252404105.jpeg?auto=format&w=1200&q=60",                    
                    Description = "Lachlan Giles , Autstralian black belt, is coming to Varna , Bulgaria to host a Seminar.",
                    IsRemoved = false,
                    Location = "Mall Varna",
                    MembersPrice = 50.00m,
                    NonMembersPrice = 60.00m,
                    Organiser = "BJJ Varna",
                    Teacher = "Lachlan Giles"
                }
            );


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

﻿// <auto-generated />
using System;
using EuropeBJJ.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EuropeBJJ.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241118102055_Refactoring2")]
    partial class Refactoring2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EuropeBJJ.Data.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Event");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("EuropeBJJ.Data.Models.OrganizedEventAccount", b =>
                {
                    b.Property<int>("OrganizedEventId")
                        .HasColumnType("int");

                    b.Property<string>("AccountId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrganizedEventId", "AccountId");

                    b.HasIndex("AccountId");

                    b.ToTable("OrganizedEventsAccounts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("EuropeBJJ.Data.Models.OpenMat", b =>
                {
                    b.HasBaseType("EuropeBJJ.Data.Models.Event");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("MembersPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NonMembersPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Organiser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("AccountId");

                    b.HasDiscriminator().HasValue("OpenMat");
                });

            modelBuilder.Entity("EuropeBJJ.Data.Models.Seminar", b =>
                {
                    b.HasBaseType("EuropeBJJ.Data.Models.Event");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("MembersPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("NonMembersPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Organiser")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Teacher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("AccountId");

                    b.ToTable("Events", t =>
                        {
                            t.Property("AccountId")
                                .HasColumnName("Seminar_AccountId");

                            t.Property("Description")
                                .HasColumnName("Seminar_Description");

                            t.Property("IsRemoved")
                                .HasColumnName("Seminar_IsRemoved");

                            t.Property("Location")
                                .HasColumnName("Seminar_Location");

                            t.Property("MembersPrice")
                                .HasColumnName("Seminar_MembersPrice");

                            t.Property("NonMembersPrice")
                                .HasColumnName("Seminar_NonMembersPrice");

                            t.Property("Organiser")
                                .HasColumnName("Seminar_Organiser");
                        });

                    b.HasDiscriminator().HasValue("Seminar");
                });

            modelBuilder.Entity("EuropeBJJ.Data.Models.Tournament", b =>
                {
                    b.HasBaseType("EuropeBJJ.Data.Models.Event");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Tournament");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Sofia",
                            Country = "Bulgaria",
                            Date = new DateTime(2024, 11, 18, 12, 20, 54, 768, DateTimeKind.Local).AddTicks(1623),
                            Discriminator = "Tournament",
                            Image = "https://smoothcomp.com/pictures/t/4582681-vxth/adcc-balkan-open-championships-2024.png",
                            Name = "ADCC Balkans Open",
                            Link = "https://smoothcomp.com/en/event/17862"
                        },
                        new
                        {
                            Id = 2,
                            City = "Sofia",
                            Country = "Bulgaria",
                            Date = new DateTime(2024, 11, 18, 12, 20, 54, 768, DateTimeKind.Local).AddTicks(1674),
                            Discriminator = "Tournament",
                            Image = "https://smoothcomp.com/pictures/t/4794848-q7z/2024-bulgarian-jiu-jitsu-championship.jpg",
                            Name = "AGF 2024 BULGARIAN JIU JITSU CHAMPIONSHIPS",
                            Link = "https://agf.smoothcomp.com/en/event/19393"
                        },
                        new
                        {
                            Id = 3,
                            City = "Sofia",
                            Country = "Bulgaria",
                            Date = new DateTime(2024, 11, 18, 12, 20, 54, 768, DateTimeKind.Local).AddTicks(1678),
                            Discriminator = "Tournament",
                            Image = "https://ajptour.com/build/webpack/img/ajp/fallback.a01f59147724b9274315365bd75f5b21.jpg",
                            Name = "AJP TOUR BULGARIA NATIONAL JIU-JITSU CHAMPIONSHIP 2024 - GI & NO-GI",
                            Link = "https://ajptour.com/en/event/1104"
                        },
                        new
                        {
                            Id = 4,
                            City = "Lisbon",
                            Country = "Portugal",
                            Date = new DateTime(2024, 11, 18, 12, 20, 54, 768, DateTimeKind.Local).AddTicks(1681),
                            Discriminator = "Tournament",
                            Image = "https://ibjjf.com/rails/active_storage/blobs/eyJfcmFpbHMiOnsibWVzc2FnZSI6IkJBaHBBam9hIiwiZXhwIjpudWxsLCJwdXIiOiJibG9iX2lkIn19--17bf4a00266e5788a79c44d985d0b399c0ab0bec/lisbon-2024-logo-website-white%20(1).png",
                            Name = "Lisbon International Open IBJJF Jiu-Jitsu Championship 2024",
                            Link = "https://ibjjf.com/events/lisbon-international-open-ibjjf-jiu-jitsu-championship-2024"
                        });
                });

            modelBuilder.Entity("EuropeBJJ.Data.Models.OrganizedEventAccount", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EuropeBJJ.Data.Models.Event", "OrganizedEvent")
                        .WithMany()
                        .HasForeignKey("OrganizedEventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("OrganizedEvent");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EuropeBJJ.Data.Models.OpenMat", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("EuropeBJJ.Data.Models.Seminar", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartApp.Models;

namespace SmartApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Smartphone> Smartphones { get; set; }

        public DbSet<OpSystem> OpSystems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            //seed Genres
            modelBuilder.Entity<OpSystem>().HasData(new OpSystem{ Id = 1, OsType = "IOS" });
            modelBuilder.Entity<OpSystem>().HasData(new OpSystem{ Id = 2, OsType = "Android" });
            modelBuilder.Entity<OpSystem>().HasData(new OpSystem { Id = 3, OsType = "Harmony OS" });

            //seed Books
            modelBuilder.Entity<Smartphone>().HasData(new Smartphone
            {
                Id = 100,
                Name = "Iphone X",
                Manufacturer = "Apple",
                Price = "€1,500",
                Released = new DateTime(2017, 08, 30, 0, 0, 0),
                isAvailable = true,
                OperatingSystemId = 1

            });

            modelBuilder.Entity<Smartphone>().HasData(new Smartphone
            {
                Id = 200,
                Name = "Iphone XI",
                Manufacturer = "Apple",
                Price = "€1,650",
                Released = new DateTime(2018, 08, 25, 0, 0, 0),
                isAvailable = true,
                OperatingSystemId = 1

            });
            modelBuilder.Entity<Smartphone>().HasData(new Smartphone
            {
                Id = 300,
                Name = "Samsung Galaxy S20",
                Manufacturer = "Samsung",
                Price = "€1,400",
                Released = new DateTime(2020, 02, 12, 0, 0, 0),
                isAvailable = true,
                OperatingSystemId = 2

            });
            modelBuilder.Entity<Smartphone>().HasData(new Smartphone
            {
                Id = 400,
                Name = "Huawei Mate 30",
                Manufacturer = "Huawei",
                Price = "€2,500",
                Released = new DateTime(2019, 08, 11, 0, 0, 0),
                isAvailable = true,
                OperatingSystemId = 3

            });
        }
    }
}

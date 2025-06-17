using Microsoft.EntityFrameworkCore;
using Carsalesbyhoho.Models;
using System.Numerics;
using System.IO;


namespace Carsalesbyhoho.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<AutoType> AutoTypes { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Verkoop> Verkopen { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Carsalesbyhoho.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Brand>().HasData(
            new Brand { Id = 1, Naam = "Diesel" },
            new Brand { Id = 2, Naam = "Benzine" },
            new Brand { Id = 3, Naam = "Elektrisch" });

            modelBuilder.Entity<AutoType>().HasData(
            new AutoType { Id = 1, Omschrijving = "SUV" },
            new AutoType { Id = 2, Omschrijving = "Break" },
            new AutoType { Id = 3, Omschrijving = "Sedan" },
            new AutoType { Id = 4, Omschrijving = "Hatchback" },
            new AutoType { Id = 5, Omschrijving = "Cabriolet" });

        }
    }
}

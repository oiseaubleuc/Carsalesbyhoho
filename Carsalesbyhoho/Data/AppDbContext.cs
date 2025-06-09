using Microsoft.EntityFrameworkCore;
using Carsalesbyhoho.Models;
using System.Numerics;

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
        }
    }
}

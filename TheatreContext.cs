using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheatreBooking.Model;

namespace TheatreBooking
{
    public class TheatreContext : DbContext
    {
        private static TheatreContext instance;
        public TheatreContext()
        {
            Database.EnsureCreated();
           // Database.EnsureDeleted();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DARIMA\\SQLEXPRESS;Database=TheatreBooking;Trusted_Connection=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Administrrator>().HasData(
                new Administrrator() {Id=1, Login = "admin", Password = "root" });
            modelBuilder.Entity<Genre>().HasData(
                new Genre() {Id=1, Title = "Comedy" },
                new Genre() {Id = 2, Title = "Drama" },
                new Genre() {Id = 3, Title = "Opera" });
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Administrrator> Administrators { get; set; }
        public DbSet<Afisha> Afisha { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Saal> Saal { get; set; }
        public DbSet<Spectacle> Spectacles { get; set; }
        public DbSet<User> Users { get; set; }
        public static TheatreContext Instance
        {
            get
            {
                if (instance == null) { instance = new TheatreContext(); }
                return instance;
            }
        }

    }
}

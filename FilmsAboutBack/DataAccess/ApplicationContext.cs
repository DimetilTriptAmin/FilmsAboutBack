using FilmsAboutBack.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace FilmsAboutBack.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<IdentityUserLogin>()
               .HasKey(u => u.UserId);
            modelBuilder.Entity<IdentityUserRole>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<IdentityUserClaim>()
                .HasKey(u => u.UserId);


            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Comment>()
                .HasNoKey();

            modelBuilder.Entity<Rating>()
                .HasNoKey();
        }

    }
}

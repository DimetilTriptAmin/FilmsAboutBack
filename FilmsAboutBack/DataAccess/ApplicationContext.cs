using FilmsAboutBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmsAboutBack.DataAccess
{
    public class ApplicationContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            for (int i = 1; i < 6; i++)
            {
                modelBuilder.Entity<Film>().HasData(new Film
                {
                    Id = i,
                    Title = "film" + i.ToString(),
                    Description = "film #" + i.ToString(),
                    Poster = new byte[2],
                }) ;
            }

            for (int i = 1; i < 6; i++)
            {
                modelBuilder.Entity<User>().HasData(new User
                {
                    Id = i,
                    BirthDate = new System.DateTime().Date,
                    LockoutEnabled = false,
                    TwoFactorEnabled = false,
                    EmailConfirmed = false,
                    PhoneNumberConfirmed = false,
                    AccessFailedCount = 0,
                }) ;
                
            }

            modelBuilder.Entity<IdentityUserLogin<int>>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<IdentityUserRole<int>>()
                .HasKey(r => r.RoleId);

            modelBuilder.Entity<IdentityUserToken<int>>()
                .HasKey(t => t.UserId);

            modelBuilder.Entity<Rating>()
                .HasKey(c => new { c.UserId, c.FilmId });
        }

    }
}

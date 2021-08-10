using FilmsAboutBack.Helpers;
using FilmsAboutBack.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Text;

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
            #region FilmSeeding
            modelBuilder.Entity<Film>().HasData(new Film
            {
                Id = 1,
                Title = "Fight Club",
                Description = "An insomniac office worker and a devil-may-care soap maker form an underground " +
                    "fight club that evolves into much more.",
                Poster = Base64Coder.EncodeImg(Path.GetFullPath(@"../FilmsAboutBack/Assets/posters/fight_club.jpg")),
                Rating = 4.7,
                TrailerLink= "https://www.youtube.com/watch?v=O1nDozs-LxI&ab_channel=FilmFeed",
            });

            modelBuilder.Entity<Film>().HasData(new Film
            {
                Id = 2,
                Title = "Scarface",
                Description = "In 1980 Miami, a determined Cuban immigrant takes over a drug cartel and succumbs to greed.",
                Poster = Base64Coder.EncodeImg(Path.GetFullPath(@"../FilmsAboutBack/Assets/posters/scarface.jpg")),
                Rating = 4.8,
                TrailerLink= "https://www.youtube.com/watch?v=7pQQHnqBa2E&ab_channel=FaceOff",
            });

            modelBuilder.Entity<Film>().HasData(new Film
            {
                Id = 3,
                Title = "Gentlemen",
                Description = "An American expat tries to sell off his highly profitable marijuana empire " +
                    "in London, triggering plots, schemes, bribery and blackmail in an attempt to steal his domain " +
                    "out from under him.",
                Poster = Base64Coder.EncodeImg(Path.GetFullPath(@"../FilmsAboutBack/Assets/posters/the_gentlemen.jpg")),

                Rating = 4.5,
                TrailerLink = "https://www.youtube.com/watch?v=Ify9S7hj480&ab_channel=MovieclipsTrailers"
            }); ;

            modelBuilder.Entity<Film>().HasData(new Film
            {
                Id = 4,
                Title = "Pulp Fiction",
                Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner " +
                    "bandits intertwine in four tales of violence and redemption.",
                Poster = Base64Coder.EncodeImg(Path.GetFullPath(@"../FilmsAboutBack/Assets/posters/pulp_fiction.jpg")),
                Rating = 4.9,
                TrailerLink = "https://www.youtube.com/watch?v=s7EdQ4FqbhY&ab_channel=Movieclips",
            });

            modelBuilder.Entity<Film>().HasData(new Film
            {
                Id = 5,
                Title = "The Devil's Advocate",
                Description = "An exceptionally adept Florida lawyer is offered a job at a high-end New York City " +
                    "law firm with a high-end boss - the biggest opportunity of his career to date.",
                Poster = Base64Coder.EncodeImg(Path.GetFullPath(@"../FilmsAboutBack/Assets/posters/the_devils_advocate.jpg")),

                Rating = 4.2,
                TrailerLink= "https://www.youtube.com/watch?v=40hHA9n4C2o&ab_channel=MovieclipsClassicTrailers",
            });
            #endregion

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

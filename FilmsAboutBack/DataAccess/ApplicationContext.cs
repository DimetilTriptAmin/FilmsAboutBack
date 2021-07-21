﻿using FilmsAboutBack.Models;
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

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<IdentityUserLogin>();
            modelBuilder.Ignore<IdentityUserRole>();
            modelBuilder.Ignore<IdentityUserClaim>();

            //modelBuilder.Entity<IdentityUserLogin>()
            //   .HasNoKey();
            //modelBuilder.Entity<IdentityUserRole>()
            //    .HasKey(u => u.UserId);
            //modelBuilder.Entity<IdentityUserClaim>()
            //    .HasKey(u => u.UserId);


            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);

            modelBuilder.Entity<Comment>()
                .HasNoKey();

            modelBuilder.Entity<Rating>()
                .HasNoKey();
        }

    }
}

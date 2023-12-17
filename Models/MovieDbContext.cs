using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CsvHelper;
using CsvHelper.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MovieApplication
{
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Occupation> Occupations { get; set; }
        public DbSet<UserMovie> UserMovies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(configuration.GetConnectionString("MovieLens"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().ToTable("movies");
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Occupation>().ToTable("occupations");

            // Movie Entity
            modelBuilder.Entity<Movie>()
                .ToTable("movies", "guest")
                .HasKey(m => m.MovieId); 

            // User Entity
            modelBuilder.Entity<User>()
                .ToTable("users", "guest")
                .HasKey(u => u.UserId);

            // Occupation Entity
            modelBuilder.Entity<Occupation>()
                .ToTable("occupations", "guest") 
                .HasKey(o => o.OccupationId); 
          
            // UserDetail Entity
            modelBuilder.Entity<UserDetail>()
                .ToTable("userdetails", "guest")
                .HasKey(ud => ud.Id); // 
            modelBuilder.Entity<UserDetail>()
                .HasOne(ud => ud.User)
                .WithOne(u => u.UserDetail)
                .HasForeignKey<UserDetail>(ud => ud.UserId);

            // UserMovie (Ratings) Entity
            modelBuilder.Entity<UserMovie>()
                .ToTable("ratings", "dbo") 
                .HasKey(um => um.Id); 
                modelBuilder.Entity<UserMovie>()
        .Property(um => um.Rating)
        .HasPrecision(18, 3); 
            modelBuilder.Entity<UserMovie>()
                .HasOne(um => um.User)
                .WithMany(u => u.UserMovies)
                .HasForeignKey(um => um.UserId);
            modelBuilder.Entity<UserMovie>()
                .HasOne(um => um.Movie)
                .WithMany(m => m.UserMovies)
                .HasForeignKey(um => um.MovieId);


        }
    }
}

﻿using Bulky.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; } //create table with the entity Category

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 2, Name = "Scifi", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Horror", DisplayOrder = 3 },
                new Category { Id = 4, Name = "Documentary", DisplayOrder = 4 },
                new Category { Id = 5, Name = "Romance", DisplayOrder = 5 },
                new Category { Id = 6, Name = "Thriller", DisplayOrder = 6 }
            );
        }
    }
}

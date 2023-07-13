﻿using Microsoft.EntityFrameworkCore;

namespace BookStore.Data
{
    public class BookStoreDbContext : DbContext
    {
        private readonly BookStoreDbContext _dbContext;
        public BookStoreDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<CreateBook> Books { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
      
 
        


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
                


            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "User" },
                new Role { Id = 2, Name = "Manager" },
                new Role { Id = 3, Name = "Administrator" });

            modelBuilder.Entity<CreateBook>().HasData(
                new CreateBook
                {
                    Id = 1,
                    Title = "Lalka",
                    FirstNameOfAuthor = "Bolesław",
                    LastNameOfAuthor = "Prus",
                    Species = "Obraz społeczeństwa warszawskiego w drugiej połowie XIX wieku.",
                    NumberOfPages = 860,
                    PublicationDate = new DateTime(1890, 01, 25),
                });
            base.OnModelCreating(modelBuilder);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContactsData
{
    public class ContactsContext : DbContext
    {
        public ContactsContext() : base() { } // just calls the base class constructor
        // need to add another constructor for connection string in appsettings.json
        // (uses dependency injection)
        public ContactsContext(DbContextOptions<ContactsContext> options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    // provide connection string
        //    optionsBuilder.UseSqlServer("Server=localhost\\sqlexpress;Database=Contacts;Trusted_Connection=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    FirstName = "Steve",
                    LastName = "Osten",
                    Phone = "587-654-1111",
                    Email = "osten26@yahoo.com",
                    CategoryId = "Friend",
                    Created = DateTime.Now
                },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "Wanda",
                    LastName = "Suther",
                    Phone = "825-623-4548",
                    Email = "wandaring@outlook.com",
                    CategoryId = "Work",
                    Created = DateTime.Now
                },
                new Contact
                {
                    ContactId = 3,
                    FirstName = "Marvin",
                    LastName = "Markson",
                    Phone = "780-961-2526",
                    Email = "marks0n.m@gmail.com",
                    CategoryId = "Family",
                    Created = DateTime.Now
                }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "Friend", Name = "Friend" },
                new Category { CategoryId = "Work", Name = "Work" },
                new Category { CategoryId = "Family", Name = "Family" }
            );
        }
    }
}

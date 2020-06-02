using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;
using HomeWork25._05.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HomeWork25._05.DB
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) 
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers {get;set;}
        public DbSet<Role> Roles {get;set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Default");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, CategoryName = "Technical"},
                new Category() { Id = 2, CategoryName = "Food"}
                );
            modelBuilder.Entity<Role>().HasData(
                new Role(){Id =1, RoleName = "Admin"},
                new Role() {Id = 2,RoleName = "Customer"}
            );
            modelBuilder.Entity<Customer>().HasData(
                new Customer(){Id = 1 , RoleId = 1,Login = "@dmin", Password = "123."},
                new Customer(){Id = 2 , RoleId = 2,Login = "customer", Password = "12345",Adress = "Dushanbe city, Ayni street, House 65",PhoneNumber = 111010070}
            );
        }
    }
}

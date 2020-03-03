namespace TeamTest.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Microsoft.EntityFrameworkCore;
    using TeamTest.Models.Entities;

    class SpaContext : DbContext
    {
        // cd TeamTest.Repositories
        // dotnet ef migrations add InitialCreate
        // dotnet ef database update

        private const string _connectionString = "Data Source=TeamSpa.db";

        public DbSet<Brand> Brand { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Seeding Categories information 
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Tech," });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Services," });
            modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Office." });

            // Seeding Categories information 
            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 1, Name = "Nike" });
            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 2, Name = "Adidas" });
            modelBuilder.Entity<Brand>().HasData(new Brand { Id = 3, Name = "Under Armour" });
        }
    }
}

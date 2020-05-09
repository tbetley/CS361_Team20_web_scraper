using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace web_scraper.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed categories
            modelBuilder.Entity<Category>().HasData(new Category
                {CategoryId = 1, CategoryName = "TV", Description = "Televisions"});

            modelBuilder.Entity<Category>().HasData(new Category
                { CategoryId = 2, CategoryName = "Accessory", Description = "Accessories" });

            // seed Tv
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 1,
                Brand = "Samsung",
                Model = "UN65TU8000FXZA",
                ShortDescription = "Samsung 65 inch TU 8000",
                LongDescription = "Samsung 65 inch TU 8000 Series 4K TV",
                Price = 697.99M,
                ImageUrl = "",
                ImageThumbnailUrl = "",
                CategoryId = 1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                Brand = "TCL",
                Model = "55S425",
                ShortDescription = "TCL 55 inch 4 Series",
                LongDescription = "TCL 55 inch 4 Series 4K TV",
                Price = 279.99M,
                ImageUrl = "",
                ImageThumbnailUrl = "",
                CategoryId = 1
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                Brand = "Logitech",
                Model = "Harmony 950",
                ShortDescription = "Logitech Harmony Remote 950",
                LongDescription = "Logitech Harmony Remote 950 Advanced Universal Remote",
                Price = 249.99M,
                ImageUrl = "",
                ImageThumbnailUrl = "",
                CategoryId = 2
            });
        }
    }
}

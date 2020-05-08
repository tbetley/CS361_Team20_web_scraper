using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_scraper.Models
{
    public class MockProductRepository : IProductRepository
    {

        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Product> allProducts =>
            new List<Product>
            {
                new Product{ProductID=1, Name="big tv", Manufacturer="nah", Model="235jqgaseo", Price=0.35M, ImageUrl="tvshopper.com/big_tv_pic.png", SiteUrl="tvshopper.com/big_tv"},
                new Product{ProductID=2, Name="tiny laptop", Manufacturer="grapefruit", Model="aht2o3uipht", Price=215082.23M, ImageUrl="grapefruit.com/270t907.png", SiteUrl="grapefruit.com/products/thebestone"},
                new Product{ProductID=3, Name="power tower", Manufacturer="Asuspect", Model="h1p23th589hgas", Price=2352.99M, ImageUrl="pcshopper.com/yournexttower.png", SiteUrl="pcshopper.com/search?=23985y7ashtohgoah4t7892wa"}
            };

        public Product getProductById(int productID)
        {
            return allProducts.FirstOrDefault(p => p.ProductID == productID);
        }

    }
}

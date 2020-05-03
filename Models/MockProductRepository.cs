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
                new Product{id=1, name="big tv", manufacturer="nah", model="235jqgaseo", price=0.35M, Category=_categoryRepository.allCategories.ToList()[0]},
                new Product{id=2, name="tiny laptop", manufacturer="grapefruit", model="aht2o3uipht", price=215082.23M, Category=_categoryRepository.allCategories.ToList()[1]},
                new Product{id=3, name="power tower", manufacturer="Asuspect", model="h1p23th589hgas", price=2352.99M, Category=_categoryRepository.allCategories.ToList()[2]}
            };

        public Product getProductById(int productID)
        {
            return allProducts.FirstOrDefault(p => p.id == productID);
        }
    }
}

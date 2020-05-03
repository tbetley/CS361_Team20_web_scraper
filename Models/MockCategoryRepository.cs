using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_scraper.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> allCategories =>
            new List<Category>
            {
                new Category{id=1, name="TVs"},
                new Category{id=2, name="Laptops"},
                new Category{id=3, name="Desktops"}
            };
    }
}

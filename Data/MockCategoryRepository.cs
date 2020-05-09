using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Models;

namespace web_scraper.Data
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> allCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, Name="TVs", Urls =
                    new List<String>()
                        {
                            "bigtvs.com",
                            "bettertvs.com",
                            "uglytvs.com"
                        }
                    },
                new Category{CategoryId=2, Name="Laptops", Urls =
                    new List<String>()
                        {
                            "computers.com",
                            "pineapple.com",
                            "bugdetelectronics.com"
                        }
                    },
                new Category{CategoryId=3, Name="Desktops", Urls =
                    new List<String>()
                        {
                            "computers.com",
                            "asuspect.com",
                            "pineapple.com"
                        }
                    }
            };

        public Category getCategoryById(int id)
        {
            return allCategories.FirstOrDefault(c => c.CategoryId == id);
        }
    }
}

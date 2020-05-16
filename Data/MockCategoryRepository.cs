using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Models;
using web_scraper.Scraper;

namespace web_scraper.Data
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> allCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, Name="TVs", sites =
                    new List<ISiteScraper>()
                        {
                            new BestBuyScraper("http://bestbuy.com/site/tvs/all-flat-screen-tvs/abcat0101001.c?id=abcat0101001"),
                        }
                    },
                new Category{CategoryId=2, Name="Laptops", sites =
                    new List<ISiteScraper>()
                        {
                            new DellDealsScraper("http://deals.dell.com/en-us/category/laptops"),
                        }
                    },
                new Category{CategoryId=3, Name="Desktops", sites =
                    new List<ISiteScraper>()
                        {
                            new DellDealsScraper("http://deals.dell.com/en-us/category/desktops"),
                        }
                    }
            };

        public Category getCategoryById(int id)
        {
            return allCategories.FirstOrDefault(c => c.CategoryId == id);
        }
    }
}

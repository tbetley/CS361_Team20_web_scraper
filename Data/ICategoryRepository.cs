using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Data;
using web_scraper.Models;

namespace web_scraper.Data
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> allCategories { get; }

        Category getCategoryById(int id);
    }
}

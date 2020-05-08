using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_scraper.Models
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> allCategories { get; }

        Category getCategoryById(int id);
    }
}

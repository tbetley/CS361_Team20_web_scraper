using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;
using web_scraper.Scraper;

namespace web_scraper.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        public string Name { get; set; }

        public List<ISiteScraper> sites { get; set; }

        public string Description { get; set; }
    }
}

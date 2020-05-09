using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace web_scraper.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        public string Name { get; set; }

        public List<String> Urls { get; set; }

        public string Description { get; set; }
    }
}

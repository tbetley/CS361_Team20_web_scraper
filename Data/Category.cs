using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace web_scraper.Data
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public List<Tv> Tv { get; set; }
    }
}

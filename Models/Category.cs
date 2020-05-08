using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_scraper.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string Name { get; set; }

        public IEnumerable<String> Urls { get; set; }
    }
}

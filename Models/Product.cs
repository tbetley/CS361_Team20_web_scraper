using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_scraper.Models
{
    public class Product
    {
        public int id { get; set; }

        public string manufacturer { get; set; }

        public string model { get; set; }

        public string name { get; set; }

        public decimal price { get; set; }

        public Category Category { get; set; }
    }
}

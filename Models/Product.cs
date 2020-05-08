using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_scraper.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        public string Name { get; set; }

        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string SiteUrl { get; set; }
    }
}

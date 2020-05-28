using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Data;
using web_scraper.Models;

namespace web_scraper.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<SelectListItem> CategoryListItems { get; set; }

        public string categorychosen { get; set; }
        public IEnumerable<SelectListItem> filterString { get; set; }
        public string filterSelected { get; set; }
        public string searchString { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string URL { get; set; }
    }
}

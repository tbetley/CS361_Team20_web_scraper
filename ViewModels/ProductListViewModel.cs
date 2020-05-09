using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Data;

namespace web_scraper.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        
        public string CurrentCategory { get; set; }
    }
}

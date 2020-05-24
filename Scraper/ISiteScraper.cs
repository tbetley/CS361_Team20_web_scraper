using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Models;

namespace web_scraper.Scraper
{
    public interface ISiteScraper
    {
        //List<Product> GetProducts();

        void AddProductsToList(List<Product> list);
    }
}

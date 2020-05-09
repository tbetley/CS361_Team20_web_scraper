using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Data;
using web_scraper.Models;

namespace web_scraper.Data
{
    public interface IProductRepository
    {
        IEnumerable<Product> allProducts { get; }

        Product getProductById(int productID);

    }
}

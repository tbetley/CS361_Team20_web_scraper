using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace web_scraper.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> allProducts { get; }

        Product getProductById(int productID);
    }
}

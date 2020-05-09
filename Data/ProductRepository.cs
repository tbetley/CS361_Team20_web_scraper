using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace web_scraper.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _applicationDbContext.Products.Include(c => c.Category);
            }
        }

        public Product GetProductById(int productId)
        {
            return _applicationDbContext.Products.FirstOrDefault(p => p.ProductId == productId);
        }
    }
}

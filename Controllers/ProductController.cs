using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using web_scraper.Data;
using web_scraper.ViewModels;


// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace web_scraper.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            ProductListViewModel tvListViewModel = new ProductListViewModel();
            tvListViewModel.Products = _productRepository.AllProducts;

            return View(tvListViewModel);
        }
    }
}

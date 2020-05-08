using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Models;
using web_scraper.ViewModels;

namespace web_scraper.Controllers
{
    public class ProductController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;

        [BindProperty(SupportsGet = true)]
        public Category CategoryRequested { get; set; }


        public ProductListViewModel ViewModel;

        public ProductController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            ViewModel = new ProductListViewModel();
            ViewModel.Categories = _categoryRepository.allCategories;
            ViewModel.Products = new List<Product>();
        }

        public ViewResult List(string category)
        {
            if (!String.IsNullOrEmpty(category))
            {
                if(Int32.TryParse(category, out int id))
                {
                    ViewModel.Products = Scraper.Scraper.SearchByCategory(_categoryRepository.getCategoryById(id));
                }
                else
                {
                    //error parsing id
                }

            }
            
            return View(ViewModel);
        }


    }
}

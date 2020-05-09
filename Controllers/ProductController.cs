using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using web_scraper.Data;
using web_scraper.Models;
using web_scraper.ViewModels;

namespace web_scraper.Controllers
{
    public class ProductController : Controller
    {

        private readonly ICategoryRepository _categoryRepository;

        public ProductListViewModel ViewModel;

        public ProductController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            ViewModel = new ProductListViewModel();
            //gets hard-coded category list to populate drop-down
            ViewModel.CategoryListItems = getCategoryListItems(_categoryRepository.allCategories);
            //empty list of products to be filled by scraper
            ViewModel.Products = new List<Product>();
        }

        /**
         * handles GET requests to the List page, optionally with 'category' parameter from hmtl option element
         * 'category' is passed as a string but it actually represents an integer category ID
         * */
        public ViewResult List(ProductListViewModel model)
        {
            if (!String.IsNullOrEmpty(model.categorySelected))
            {
                if(Int32.TryParse(model.categorySelected, out int id))
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

        /*
         * Generates SelectListItems for each of the categories in the list, where the value will
         * be the category's ID and the text is the category's name
         * */
        private IEnumerable<SelectListItem> getCategoryListItems(IEnumerable<Category> categoryList)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach(Category cat in categoryList)
            {
                selectList.Add(new SelectListItem
                {
                    Value = cat.CategoryId.ToString(),
                    Text = cat.Name
                });
            }

            return selectList;
        }

    }
}

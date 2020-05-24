using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using web_scraper.Data;
using web_scraper.Models;
using web_scraper.ViewModels;

namespace web_scraper.Controllers
{
    public class ProductController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public ProductListViewModel ViewModel;
        public string sortOrder;

        public ProductController(ICategoryRepository categoryRepository)
        {
            IEnumerable<string> filterStrings = new List<string> { "Name", "Model", "Price", "Manufactuer", "URL" };
            _categoryRepository = categoryRepository;
            ViewModel = new ProductListViewModel();
            //gets hard-coded category list to populate drop-down
            ViewModel.CategoryListItems = getCategoryListItems(_categoryRepository.allCategories);
            //empty list of products to be filled by scraper
            ViewModel.Products = new List<Product>();
            ViewModel.filterString = getFilterItems(filterStrings);
        }

        /**
         * handles GET requests to the List page, optionally with 'category' parameter from hmtl option element
         * 'category' is passed as a string but it actually represents an integer category ID
         * */

        public ViewResult List(ProductListViewModel model, string searchString)
        {
            if (!String.IsNullOrEmpty(model.categorychosen))
            {
                ViewData["NameSortParm"] = sortOrder == "Name" ? "name_asc" : "Name";
                ViewData["ModelSortParm"] = sortOrder == "Model" ? "model_asc" : "Model";
                ViewData["PriceSortParm"] = sortOrder == "Price" ? "price_asc" : "Price";
                ViewData["ManufacturerSortParm"] = sortOrder == "Manufacturer" ? "manu_asc" : "Manufacturer";
                ViewData["UrlSortParm"] = sortOrder == "Url" ? "url_desc" : "Url";

                if (Int32.TryParse(model.categorychosen, out int id))
                {
                    ViewModel.Products = Scraper.Scraper.SearchByCategory(_categoryRepository.getCategoryById(id));
                    if (model.filterSelected == "Price")
                        ViewModel.Products = ViewModel.Products.OrderBy(o => o.Price);
                    if (model.filterSelected == "Name")
                        ViewModel.Products = ViewModel.Products.OrderBy(o => o.Name);
                    if (model.filterSelected == "Manufacturer")
                        ViewModel.Products = ViewModel.Products.OrderBy(o => o.Model);
                    if (model.filterSelected == "URL")
                        ViewModel.Products = ViewModel.Products.OrderBy(o => o.SiteUrl);
                }
                else
                {
                    //error parsing id
                }
            }
            if (!String.IsNullOrEmpty(model.searchString))
            {
                ViewModel.Products = Scraper.Scraper.SearchByCategory(_categoryRepository.getCategoryById(1));
                ViewModel.Products = ViewModel.Products.Where(s => s.Name.Contains(searchString));

                return View(ViewModel);
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

            foreach (Category cat in categoryList)
            {
                selectList.Add(new SelectListItem
                {
                    Value = cat.CategoryId.ToString(),
                    Text = cat.Name
                });
            }

            return selectList;
        }

        private IEnumerable<SelectListItem> getFilterItems(IEnumerable<string> filterList)
        {
            List<SelectListItem> selectList = new List<SelectListItem>();

            foreach (string cat in filterList)
            {
                selectList.Add(new SelectListItem
                {
                    Value = cat,
                    Text = cat
                });
            }

            return selectList;
        }
    }
}
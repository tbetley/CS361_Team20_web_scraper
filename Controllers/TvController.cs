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
    public class TvController : Controller
    {
        private readonly ITvRepository _tvRepository;
        private readonly ICategoryRepository _categoryRepository;

        public TvController(ITvRepository tvRepository, ICategoryRepository categoryRepository)
        {
            _tvRepository = tvRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            TvListViewModel tvListViewModel = new TvListViewModel();
            tvListViewModel.Tv = _tvRepository.AllTv;

            return View(tvListViewModel);
        }
    }
}

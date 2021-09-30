using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Repository;
using WatchesShop.ViewModels;

namespace WatchesShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWatch watchRep;
        public HomeController(IWatch watchRep)
        {
            this.watchRep = watchRep;
        }
        public ViewResult Index()
        {
            var homeWatch = new HomeViewModel()
            { 
                favWatch = watchRep.getFavWatch,
                getNewWatch = watchRep.getNewWatch
                
                
            };
            return View(homeWatch);

        }
    }
}

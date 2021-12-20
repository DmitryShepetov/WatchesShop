using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Model;
using WatchesShop.ViewModels;

namespace WatchesShop.Controllers
{
    public class WatchController : Controller
    {
        private readonly IWatch watchRep;
        private readonly IWatchCategory categoryRep;
        private readonly IWatchImage watchImageRep;
        public WatchController(IWatch watchRep, IWatchCategory categoryRep, IWatchImage watchImageRep)
        {
            this.watchRep = watchRep;
            this.categoryRep = categoryRep;
            this.watchImageRep = watchImageRep;
        }
        [HttpGet]
        [Route("Watch/List")]
        public IActionResult List(string category, string type)
        {
            IEnumerable<Watch> watch = null;
            if (category != null)
            {
                watch = watchRep.AllWatch.Where(p => p.Category.categoryName == category);
            }
            if (type != null)
            {
                watch = watch.Where(p => p.type == type);
            }
            var watchObj = new WatchListViewModel
            {
                allWatch = watch
            };
            return View(watch);
        }
        [Route("Watch/Info/{name}")]
        public ViewResult Info(string name)
        {
            IEnumerable <Watch> watch = null;
            IEnumerable <WatchImage> watchImages = null;
            int id = 0;
            if (string.IsNullOrEmpty(name))
            {
                watch = watchRep.AllWatch.OrderBy(i => i.id);
            }
            else
            {
                watch = watchRep.AllWatch.Where(i => i.name == name);
                foreach(var item in watch)
                {
                    id = item.id;
                }
                watchImages = watchImageRep.WatchImages(id);
            }
            var motoObj = new WatchListViewModel
            {
                allWatch = watch,
                watchImages = watchImages
            };
            return View(motoObj);
        }
    }
}

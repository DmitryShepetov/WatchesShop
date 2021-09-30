using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Model;

namespace WatchesShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Watch> favWatch { get; set; }
        public IEnumerable<Watch> getNewWatch { get; set; }
    }
}

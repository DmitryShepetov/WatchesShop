using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Model;

namespace WatchesShop.Data.Repository
{
    public class WatchImageRepository : IWatchImage
    {
        private readonly AppDBContext appDBContext;
        public WatchImageRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<WatchImage> WatchImages(int watchId) => appDBContext.WatchImage.Where(p => p.Watch.id == watchId);
    }
}

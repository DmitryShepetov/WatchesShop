using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Model;

namespace WatchesShop.Data.Repository
{
    public class WatchRepository : IWatch
    {
        private readonly AppDBContext appDBContext;
        public WatchRepository(AppDBContext appDBContext)
        {
            this.appDBContext = appDBContext;
        }
        public IEnumerable<Watch> AllWatch => appDBContext.Watch.Include(c => c.Category);
        public IEnumerable<Watch> getFavWatch => appDBContext.Watch.Where(p => p.isFavourite).Include(c => c.Category);
        public IEnumerable<Watch> getNewWatch => appDBContext.Watch.Where(p => p.newWatch).Include(c => c.Category);
        public IEnumerable<Watch> getSortWatch(int category) => appDBContext.Watch.Where(p => p.Category.id == category);
        public async Task<Watch> getObjectWatchAsync(int watchId) => await appDBContext.Watch.FirstOrDefaultAsync(p => p.id == watchId);
    }
}

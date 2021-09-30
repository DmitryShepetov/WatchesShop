using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Model;

namespace WatchesShop.Data.Interfaces
{
    public interface IWatch
    {
        IEnumerable<Watch> AllWatch { get; }
        IEnumerable<Watch> getFavWatch { get; }
        IEnumerable<Watch> getNewWatch { get; } 
        Task<Watch> getObjectWatchAsync(int watchId);
    }
}

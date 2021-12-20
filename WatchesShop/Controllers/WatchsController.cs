using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;

namespace WatchesShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchsController : ControllerBase
    {
        private readonly IWatch watchRep;
        public WatchsController()
        {
            this.watchRep = watchRep;
        }
        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(watchRep.AllWatch);
        }
    }
}

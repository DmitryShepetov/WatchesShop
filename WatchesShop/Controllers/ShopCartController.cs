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
    public class ShopCartController : Controller
    {
        private readonly ShopCartRepository shopCartRepository;
        private readonly IWatch watchRep;
        public ShopCartController(ShopCartRepository shopCartRepository, IWatch watchRep)
        {
            this.shopCartRepository = shopCartRepository;
            this.watchRep = watchRep;
        }
        public ViewResult Cart()
        {
            var item = shopCartRepository.getShopItems;
            shopCartRepository.listShopItem = item;
            var obj = new ShopCartViewModel { shopCart = shopCartRepository };
            return View(obj);
        }
        public async Task<RedirectToActionResult> addToCart(int id)
        {
            var item = watchRep.AllWatch.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                await shopCartRepository.AddToCart(item);
            }
            return RedirectToAction("Cart");
        } 
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WatchesShop.Data.Interfaces;
using WatchesShop.Data.Model;
using WatchesShop.Data.Repository;

namespace WatchesShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrdersRep;
        private readonly ShopCartRepository shopCartRep;
        public OrderController(IAllOrders allOrdersRep, ShopCartRepository shopCartRep)
        {
            this.allOrdersRep = allOrdersRep;
            this.shopCartRep = shopCartRep;
        }
        public IActionResult Order()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Order(Order order)
        {
            shopCartRep.listShopItem = shopCartRep.getShopItems;
            if (shopCartRep.listShopItem.Count == 0)
            {
                ModelState.AddModelError("", "Вы не выбрали товары!");
            }
            else if (ModelState.IsValid)
            {
                allOrdersRep.createOrderAsync(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete()
        {
            return View();
        }
    }
}

using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Storage.Models;

namespace Storage.Controllers
{
    public class HomeController : Controller
    {
        private readonly StorageContext _storageContext;

        public HomeController(StorageContext storageContext)
        {
            this._storageContext = storageContext;
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Products");
            }

            ViewBag.ProductId = id;

            return View();
        }

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            if(ModelState.IsValid)
            {
                var orderBuff = new Order()
                {
                    User = order.User,
                    Address = order.Address,
                    Phone = order.Phone,
                    OrderDateTime = DateTime.Now,
                    Products = _storageContext.Products.Select(p => p)
                        .First(p => p.Id == order.Products.Id)
                };
            
                _storageContext.Orders.Add(orderBuff);
                _storageContext.SaveChanges();

                return RedirectToAction("Orders", "Home");
            }
            
            return View();
        }

        public IActionResult Products()
        {
            return View(_storageContext.Products.ToList());
        }

        public IActionResult Orders()
        {
            return View(_storageContext.Orders.ToList());
        }
    }
}
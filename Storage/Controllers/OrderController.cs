using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Storage.Models;

namespace Storage.Controllers
{
    public class OrderController : Controller
    {
        private readonly StorageContext _storageContext;

        public OrderController(StorageContext storageContext)
        {
            this._storageContext = storageContext;
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = _storageContext.Orders.Select(o => o).First(o => o.Id == id);

            return View(orders);
        }

        [Authorize]
        [HttpGet]
        public IActionResult OrderEdit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Order = id;

            var orders = _storageContext.Orders.Select(o => o).First(o => o.Id == id);

            return View(orders);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult OrderEdit(Order order)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            _storageContext.Orders.Update(order);
            _storageContext.SaveChanges();

            return RedirectToAction("Orders", "Home");
        }


        [HttpGet]
        public IActionResult OrderDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var removeOrder = _storageContext.Orders.Find(id);

            _storageContext.Orders.Remove(removeOrder);
            _storageContext.SaveChanges();

            return RedirectToAction("Orders", "Home");
        }
    }
}
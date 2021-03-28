using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Storage.Models;

namespace Storage.Controllers
{
    public class ProfileController : Controller
    {
        private StorageContext _storageContext;

        public ProfileController(StorageContext storageContext)
        {
            _storageContext = storageContext;
        }

        [HttpGet]
        public IActionResult ProfileUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = _storageContext.Users.FirstOrDefault(user => user.Email == User.Identity.Name);
                return View(user);
            }

            return View();
        }

        [HttpPost]
        public IActionResult ProfileUser(User user)
        {
            return View(user);
        }

        [HttpGet]
        public IActionResult EditUser()
        {
            return View();
        }
    }
}
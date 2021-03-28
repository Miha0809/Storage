using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Storage.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private Storage.Data.UserContext _userContext;

        public AdminController(Storage.Data.UserContext userContext)
        {
            this._userContext = userContext;
        }

        public IActionResult AllUsers()
        {
            return View(_userManager.Users.ToList());
        }
    }
}

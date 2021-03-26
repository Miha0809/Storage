using Microsoft.AspNetCore.Mvc;

namespace Storage.Controllers
{
    public class MainPageController : Controller
    {
        public IActionResult _ViewStart()
        {
            return View();
        }
    }
}
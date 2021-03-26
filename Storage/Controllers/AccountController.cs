using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Storage.Models;

namespace Storage.Controllers
{
    public class AccountController : Controller
    {
        private readonly StorageContext _storageContext;

        public AccountController(StorageContext storageContext)
        {
            this._storageContext = storageContext;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                var user = _storageContext.Users.FirstOrDefault(u => u.Email == register.Email);

                if (user == null)
                {
                    _storageContext.Users.Add(new User
                    {
                        Age = register.Age,
                        FirstName = register.FirstName,
                        LastName = register.LastName,
                        Phone = register.Phone,
                        Email = register.Email,
                        Address = register.Address,
                        Password = register.Password
                    });
                    
                    _storageContext.SaveChanges();
                    
                    return View();
                }
            }
            
            return View(register);
        }

       [HttpGet]
       public IActionResult Login()
       {
           return View();
       }
       
       [HttpPost]
       public IActionResult Login(LoginModel model)
       {
           if(ModelState.IsValid)
           {
               var user = _storageContext.Users.FirstOrDefault(u =>
                   u.Email == model.Email && u.Password == model.Password);

               if (user != null)
               {
                   Authentication(model.Email);
                   return RedirectToAction("Account", "Account");
               }
           }
           
           return View();
       }
       
       private void Authentication(string userName)
       {
           var claims = new List<Claim>
           {
               new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
           };

           var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
               ClaimsIdentity.DefaultRoleClaimType);
           HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
       }
       
       [HttpPost]
       public IActionResult Logout()
       {
           HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
           return RedirectToAction("_ViewStart", "MainPage");
       }

       [HttpGet]
       public IActionResult Account()
       {
           return View(_storageContext.Users.ToList());
       }
    }
}
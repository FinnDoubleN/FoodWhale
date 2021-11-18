using FoodWhale.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWhale.Controllers
{
    public class LoginController : Controller
    {
        private FoodWhaleContext context;
        public LoginController(FoodWhaleContext context) => this.context = context;
        public IActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Login()
        {
            Admin model = new Admin();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(Admin model)
        {
            var obj = context.Admins.Where(a => a.Username.Equals(model.Username) && a.Password.Equals(model.Password)).FirstOrDefault();
            if (ModelState.IsValid && obj != null)
            {
                var admin = GetByUsername(model.Username);
                var AdminSession = new Admin();
                AdminSession.Username = admin.Username;
                // Tao 1 session
                HttpContext.Session.SetString("AdminSession", JsonConvert.SerializeObject(AdminSession));
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }        
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("AdminSession");
            return RedirectToAction("Login");
        }
        public Admin GetByUsername(String username)
        {
            return context.Admins.SingleOrDefault(x => x.Username == username);
        }
    }
}

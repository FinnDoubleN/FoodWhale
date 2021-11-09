using FoodWhale_User.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWhale_User.Controllers
{
    public class CartController : Controller
    {
        private readonly FoodWhaleContext context;
        public CartController(FoodWhaleContext context) => this.context = context;
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                TempData["user"] = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                return View();
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    }
}

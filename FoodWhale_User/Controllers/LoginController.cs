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
            User model = new User();
            return View(model);
        }
        public IActionResult Register()
        {
            User model = new User();
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            var obj = context.Users.Where(a => a.Email.Equals(model.Email) && a.Password.Equals(model.Password)).FirstOrDefault();
            if (ModelState.IsValid && obj!=null)
            {
                var user = GetById(model.Email);
                var UserSession = new User();
                UserSession.Uid = user.Uid;
                // Tao 1 session
                HttpContext.Session.SetString("UserSession", JsonConvert.SerializeObject(UserSession));
                return RedirectToAction("Index", "Home");
            }
                return View(model);
        }
        [HttpPost]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var check = context.Users.FirstOrDefault(s => s.Email == model.Email);
                if (check == null)
                {
                    User register = new User();
                    register.Email = model.Email;
                    register.Password = model.Password;
                    register.Uname = model.Uname;
                    context.Users.Add(register);
                    context.SaveChanges();
                return RedirectToAction("Login", "Login");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }
            }
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserSession");
            return RedirectToAction("Index", "Home");
        }
        public User GetById(String email)
        {
            return context.Users.SingleOrDefault(x => x.Email == email);
        }
    }
}

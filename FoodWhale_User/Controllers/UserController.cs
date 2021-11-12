using FoodWhale_User.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWhale.Controllers
{
    public class UserController : Controller
    {
        private readonly FoodWhaleContext context;
        public UserController(FoodWhaleContext context) => this.context = context;
        // Show all information
        public ActionResult Index()
        {
            var model = context.Users.ToList();
            return View(model);
        }

        public User GetById(int id)
        {
            return context.Users.SingleOrDefault(x => x.UId == id);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                TempData["user"] = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                if (id == 0)
                {
                    return NotFound();
                }
                var user = context.Users.FirstOrDefault(m => m.UId == id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                TempData["user"] = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                if (id == 0)
                {
                    return NotFound();
                }
                var user = context.Users.Find(id);
                if (user == null)
                {
                    return NotFound();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                TempData["user"] = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                if (id != user.UId)
                {
                    return NotFound();
                }
                if (ModelState.IsValid)
                {
                    context.Update(user);
                    context.SaveChanges();
                }
                return View(user);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = context.Users.Find(id);
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
    }
}

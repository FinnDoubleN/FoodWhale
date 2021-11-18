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
    public class CategoryController : Controller
    {
        private readonly FoodWhaleContext context;
        public CategoryController(FoodWhaleContext context) => this.context = context;
        //Show all information
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminSession") != null)
            {
                TempData["admin"] = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("AdminSession"));
                var model = context.Categories.ToList();
            return View(model);
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

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Add(category);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category category)
        {
            if (id != category.CategoryId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(category);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);

        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

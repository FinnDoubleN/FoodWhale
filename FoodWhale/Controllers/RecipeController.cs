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
    public class RecipeController : Controller
    {
        private readonly FoodWhaleContext context;
        public RecipeController(FoodWhaleContext context) => this.context = context;
        //Show all information
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminSession") != null)
            {
                TempData["admin"] = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("AdminSession"));
                var model = context.Recipes.ToList();
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
        public ActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                context.Add(recipe);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var recipe = context.Recipes.Find(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Recipe recipe)
        {
            if (id != recipe.RId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(recipe);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);

        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var recipe = context.Recipes.Find(id);
            context.Recipes.Remove(recipe);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

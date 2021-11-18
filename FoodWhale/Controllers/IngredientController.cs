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
    public class IngredientController : Controller
    {
        private readonly FoodWhaleContext context;
        public IngredientController(FoodWhaleContext context) => this.context = context;
        //Show all information
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminSession") != null)
            {
                TempData["admin"] = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("AdminSession"));
                var model = context.Ingredients.ToList();
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
        public ActionResult Create(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                context.Add(ingredient);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var ingredient = context.Ingredients.Find(id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Ingredient ingredient)
        {
            if (id != ingredient.InId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(ingredient);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ingredient);

        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var ingredient = context.Ingredients.Find(id);
            context.Ingredients.Remove(ingredient);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

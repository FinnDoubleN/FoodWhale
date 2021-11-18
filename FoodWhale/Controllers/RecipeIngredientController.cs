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
    public class RecipeIngredientController : Controller
    {
        private readonly FoodWhaleContext context;
        public RecipeIngredientController(FoodWhaleContext context) => this.context = context;
        //Show all information
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminSession") != null)
            {
                TempData["admin"] = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("AdminSession"));
                var model = context.RecipeIngredients.ToList();
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
        public ActionResult Create(RecipeIngredient recipeingredient)
        {
            if (ModelState.IsValid)
            {
                context.Add(recipeingredient);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(recipeingredient);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var recipeingredient = context.RecipeIngredients.Find(id);
            if (recipeingredient == null)
            {
                return NotFound();
            }
            return View(recipeingredient);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeIngredient recipeingredient)
        {
            if (id != recipeingredient.RiId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(recipeingredient);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(recipeingredient);

        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var recipeingredient = context.RecipeIngredients.Find(id);
            context.RecipeIngredients.Remove(recipeingredient);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

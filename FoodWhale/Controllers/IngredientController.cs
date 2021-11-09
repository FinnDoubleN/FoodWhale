using FoodWhale.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var model = context.Ingredients.ToList();
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(String id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ingredient = context.Ingredients.FirstOrDefault(m => m.InId == id);
            if (ingredient == null)
            {
                return NotFound();
            }
            return View(ingredient);
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
        public ActionResult Edit(String id)
        {
            if (id == null)
            {
                return NotFound();
            }
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
        public ActionResult Edit(String id, Ingredient ingredient)
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
        public ActionResult Delete(String id)
        {
            var ingredient = context.Ingredients.Find(id);
            context.Ingredients.Remove(ingredient);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

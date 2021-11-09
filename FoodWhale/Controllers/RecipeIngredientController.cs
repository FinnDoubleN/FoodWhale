using FoodWhale.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var model = context.RecipeIngredients.ToList();
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var recipeIngredient = context.RecipeIngredients.FirstOrDefault(m => m.Rid == id);
            if (recipeIngredient == null)
            {
                return NotFound();
            }
            return View(recipeIngredient);
        }

        //GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipeIngredient recipeIngredient)
        {
            if (ModelState.IsValid)
            {
                context.Add(recipeIngredient);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(recipeIngredient);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var recipeIngredient = context.RecipeIngredients.Find(id);
            if (recipeIngredient == null)
            {
                return NotFound();
            }
            return View(recipeIngredient);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeIngredient recipeIngredient)
        {
            if (id != recipeIngredient.Rid)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(recipeIngredient);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(recipeIngredient);

        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var recipeIngredient = context.RecipeIngredients.Find(id);
            context.RecipeIngredients.Remove(recipeIngredient);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

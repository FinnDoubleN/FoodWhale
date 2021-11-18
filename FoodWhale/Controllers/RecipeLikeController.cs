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
    public class RecipeLikeController : Controller
    {
        private readonly FoodWhaleContext context;
        public RecipeLikeController(FoodWhaleContext context) => this.context = context;
        //Show all information
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminSession") != null)
            {
                TempData["admin"] = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("AdminSession"));
                var model = context.RecipeLikes.ToList();
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
        public ActionResult Create(RecipeLike recipelike)
        {
            if (ModelState.IsValid)
            {
                context.Add(recipelike);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(recipelike);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var recipelike = context.RecipeLikes.Find(id);
            if (recipelike == null)
            {
                return NotFound();
            }
            return View(recipelike);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipeLike recipelike)
        {
            if (id != recipelike.RlId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(recipelike);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(recipelike);

        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var recipelike = context.RecipeLikes.Find(id);
            context.RecipeLikes.Remove(recipelike);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

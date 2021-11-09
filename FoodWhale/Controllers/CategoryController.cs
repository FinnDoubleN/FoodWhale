using FoodWhale.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var model = context.Categories.ToList();
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(String id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = context.Categories.FirstOrDefault(m => m.Cid == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category categoty)
        {
            if (ModelState.IsValid)
            {
                context.Add(categoty);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoty);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(String id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoty = context.Categories.Find(id);
            if (categoty == null)
            {
                return NotFound();
            }
            return View(categoty);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String id, Category categoty)
        {
            if (id != categoty.Cid)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(categoty);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(categoty);

        }

        // GET: UserController/Delete/5
        public ActionResult Delete(String id)
        {
            var category = context.Categories.Find(id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

using FoodWhale.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWhale.Controllers
{
    public class UserAccessController : Controller
    {
        private readonly FoodWhaleContext context;
        public UserAccessController(FoodWhaleContext context) => this.context = context;
        //Show all information
        public ActionResult Index()
        {
            var model = context.UserAccesses.ToList();
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(String id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var useraccess = context.UserAccesses.FirstOrDefault(m => m.Aid == id);
            if (useraccess == null)
            {
                return NotFound();
            }
            return View(useraccess);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserAccess useraccess)
        {
            if (ModelState.IsValid)
            {
                context.Add(useraccess);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(useraccess);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(String id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var useraccess = context.UserAccesses.Find(id);
            if (useraccess == null)
            {
                return NotFound();
            }
            return View(useraccess);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(String id, UserAccess useraccess)
        {
            if (id != useraccess.Aid)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(useraccess);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(useraccess);

        }

        // GET: UserController/Delete/5
        public ActionResult Delete(String id)
        {
            var useraccess = context.UserAccesses.Find(id);
            context.UserAccesses.Remove(useraccess);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

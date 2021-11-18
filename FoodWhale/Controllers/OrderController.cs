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
    public class OrderController : Controller
    {
        private readonly FoodWhaleContext context;
        public OrderController(FoodWhaleContext context) => this.context = context;
        //Show all information
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminSession") != null)
            {
                TempData["admin"] = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("AdminSession"));
                var model = context.Orders.ToList();
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
        public ActionResult Create(Order order)
        {
            if (ModelState.IsValid)
            {
                context.Add(order);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var order = context.Orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order order)
        {
            if (id != order.OId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(order);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(order);

        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var order = context.Orders.Find(id);
            context.Orders.Remove(order);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

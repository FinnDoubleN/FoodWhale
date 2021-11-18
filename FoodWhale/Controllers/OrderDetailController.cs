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
    public class OrderDetailController : Controller
    {
        private readonly FoodWhaleContext context;
        public OrderDetailController(FoodWhaleContext context) => this.context = context;
        //Show all information
        public ActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminSession") != null)
            {
                TempData["admin"] = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("AdminSession"));
                var model = context.OrderDetails.ToList();
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
        public ActionResult Create(OrderDetail orderdetail)
        {
            if (ModelState.IsValid)
            {
                context.Add(orderdetail);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(orderdetail);
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            var orderdetail = context.OrderDetails.Find(id);
            if (orderdetail == null)
            {
                return NotFound();
            }
            return View(orderdetail);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OrderDetail orderdetail)
        {
            if (id != orderdetail.OdId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(orderdetail);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(orderdetail);

        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var orderdetail = context.OrderDetails.Find(id);
            context.OrderDetails.Remove(orderdetail);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

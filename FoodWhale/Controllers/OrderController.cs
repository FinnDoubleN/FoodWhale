using FoodWhale.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var model = context.Orders.ToList();
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var order = context.Orders.FirstOrDefault(m => m.Oid == id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
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
            if (id == 0)
            {
                return NotFound();
            }
            var order = context.OrderDetails.Find(id);
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
            if (id != order.Oid)
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

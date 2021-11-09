using FoodWhale.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            var model = context.OrderDetails.ToList();
            return View(model);
        }

        //GET: UserController/Details/5
        public ActionResult Details(String id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var orderdetail = context.OrderDetails.FirstOrDefault(m => m.Odid == id);
            if (orderdetail == null)
            {
                return NotFound();
            }
            return View(orderdetail);
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
        public ActionResult Edit(String id)
        {
            if (id == null)
            {
                return NotFound();
            }
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
        public ActionResult Edit(String id, OrderDetail orderdetail)
        {
            if (id != orderdetail.Odid)
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
        public ActionResult Delete(String id)
        {
            var orderdetail = context.OrderDetails.Find(id);
            context.OrderDetails.Remove(orderdetail);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}

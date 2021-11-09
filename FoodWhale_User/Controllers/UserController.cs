﻿using FoodWhale_User.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWhale.Controllers
{
    public class UserController : Controller
    {
        private readonly FoodWhaleContext context;
        public UserController(FoodWhaleContext context) => this.context = context;
        // Show all information
        public ActionResult Index()
        {
            var model = context.Users.ToList();
            return View(model);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var user = context.Users.FirstOrDefault(m => m.Uid == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }


        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var user = context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            if (id != user.Uid)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                context.Update(user);
                context.SaveChanges();
                return RedirectToAction(nameof(Details));
            }
            return View(user);

        }

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            var user = context.Users.Find(id);
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        
    }
}

﻿using FoodWhale_User.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWhale_User.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                TempData["user"] = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                return View();
            }
            else
            {
                return View();
            }
        }

        public IActionResult About()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                TempData["user"] = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                return View();
            }
            else
            {
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

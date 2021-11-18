using FoodWhale.Models;
using FoodWhale.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWhale.Controllers
{
    public class CartController : Controller
    {
        private readonly FoodWhaleContext context;
        public CartController(FoodWhaleContext context) => this.context = context;
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminSession") != null)
            {
                TempData["admin"] = JsonConvert.DeserializeObject<Admin>(HttpContext.Session.GetString("AdminSession"));
                List<Order> order = context.Orders.ToList();
            List<OrderDetail> orderdetail = context.OrderDetails.ToList();
            var cart = from o in order
                       join od in orderdetail on o.OId equals od.OId into table1
                       from od in table1.DefaultIfEmpty()
                       select new ViewModelCart{
                           order = o,
                           orderdetail = od
                       };
            return View(cart);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
            
        }
    }
}

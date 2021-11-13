using FoodWhale_User.Models;
using FoodWhale_User.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWhale_User.Controllers
{
    public class CartController : Controller
    {
        public class Update
        {
            public int oID { get; set; }
            public int Uid { get; set; }
            public int InId {   get; set; }
            public int newQty { get; set; }
        }

        private readonly FoodWhaleContext context;
        public CartController(FoodWhaleContext context) => this.context = context;
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                var UserSession = new User();
                UserSession = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                int Uid = UserSession.UId;
                TempData["user"] = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                List<Order> order = context.Orders.ToList();
                List<OrderDetail> orderdetail = context.OrderDetails.ToList();
                List<Ingredient> ingredient = context.Ingredients.ToList();
                var cart = from od in orderdetail
                           join o in order on od.OId equals o.OId into table1
                           from o in table1.DefaultIfEmpty()
                           join ing in ingredient on od.InId equals ing.InId into table2
                           from ing in table2.DefaultIfEmpty()
                           where o.UId == Uid
                           select new ViewModelCart
                       {
                           order = o,
                           orderdetail = od,
                           ingredient = ing
                       };
                return View(cart);
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }
        }

        [HttpPost]
        public ActionResult UpdateQty(Update updates)
        {
            List<Order> order = context.Orders.ToList();
            List<OrderDetail> orderdetail = context.OrderDetails.ToList();
            List<Ingredient> ingredient = context.Ingredients.ToList();
            var result = (from od in orderdetail
                          join o in order on od.OId equals o.OId into table1
                          from o in table1.DefaultIfEmpty()
                          join ing in ingredient on od.InId equals ing.InId into table2
                          from ing in table2.DefaultIfEmpty()
                          where o.UId == updates.Uid
                          select new ViewModelCart
                          {
                              order = o,
                              orderdetail = od,
                              ingredient = ing
                          }).ToList();
            context.SaveChanges();
            return Ok(result);
        }
    }
}

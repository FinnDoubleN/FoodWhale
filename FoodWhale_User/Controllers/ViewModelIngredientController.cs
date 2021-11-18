using FoodWhale_User.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWhale_User.Controllers
{
    public class ViewModelIngredientController : Controller
    {
        private readonly FoodWhaleContext context;
        public ViewModelIngredientController(FoodWhaleContext context) => this.context = context;
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                var UserSession = new User();
                UserSession = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                int Uid = UserSession.UId;
                TempData["user"] = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                List<Ingredient> ingredient = context.Ingredients.ToList();
                List<Category> category = context.Categories.ToList();
                var model = from i in ingredient
                            join c in category on i.CategoryId equals c.CategoryId into table1
                            from od in table1.DefaultIfEmpty()
                            select new ViewModelIngredient
                            {
                                ingredient = i,
                                category = od
                            };
                return View(model);
            }
            else
            {
                List<Ingredient> ingredient = context.Ingredients.ToList();
                List<Category> category = context.Categories.ToList();
                var model = from i in ingredient
                            join c in category on i.CategoryId equals c.CategoryId into table1
                            from od in table1.DefaultIfEmpty()
                            select new ViewModelIngredient
                            {
                                ingredient = i,
                                category = od
                            };
                return View(model);
            }
        }
    }
}

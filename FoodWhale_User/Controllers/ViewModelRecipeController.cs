using FoodWhale_User.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWhale_User.Controllers
{
    public class ViewModelRecipeController : Controller
    {
        private readonly FoodWhaleContext context;
        public ViewModelRecipeController(FoodWhaleContext context) => this.context = context;

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                var UserSession = new User();
                UserSession = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                int Uid = UserSession.UId;
                TempData["user"] = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                List<Recipe> recipe = context.Recipes.ToList();
                List<Category> category = context.Categories.ToList();
                List<RecipeIngredient> recipeIngredient = context.RecipeIngredients.ToList();
                List<Ingredient> ingredient = context.Ingredients.ToList();
                var model = from r in recipe
                            join c in category on r.CId equals c.CategoryId into table1
                            from c in table1.DefaultIfEmpty()
                            join ri in recipeIngredient on r.RId equals ri.RId into table2
                            from ri in table2.DefaultIfEmpty()
                            join i in ingredient on ri.InId equals i.InId into table3
                            from i in table3.DefaultIfEmpty()
                            select new ViewModelRecipe
                            {
                                recipe = r,
                                category = c,
                                recipeingredient = ri,
                                ingredient = i
                            };
                return View(model);
            
        }
            else
            {
                List<Recipe> recipe = context.Recipes.ToList();
                List<Category> category = context.Categories.ToList();
                var model = from r in recipe
                            join c in category on r.CId equals c.CategoryId into table1
                            from od in table1.DefaultIfEmpty()
                            select new ViewModelRecipe
                            {
                                recipe = r,
                                category = od
                            };
                return View(model);
            }
        }
        public ActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                TempData["user"] = JsonConvert.DeserializeObject<User>(HttpContext.Session.GetString("UserSession"));
                if (id == 0)
                {
                    return NotFound();
                }
                List<Recipe> recipe = context.Recipes.ToList();
                List<Category> category = context.Categories.ToList();
                List<RecipeIngredient> recipeIngredient = context.RecipeIngredients.ToList();
                List<Ingredient> ingredient = context.Ingredients.ToList();
                var model = from r in recipe
                            join c in category on r.CId equals c.CategoryId into table1
                            from c in table1.DefaultIfEmpty()
                            join ri in recipeIngredient on r.RId equals ri.RId into table2
                            from ri in table2.DefaultIfEmpty()
                            join i in ingredient on ri.InId equals i.InId into table3
                            from i in table3.DefaultIfEmpty() where r.RId == id
                            select new ViewModelRecipe
                            {
                                recipe = r,
                                category = c,
                                recipeingredient = ri,
                                ingredient = i
                            };
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
            else
            {
                if (id == 0)
                {
                    return NotFound();
                }
                List<Recipe> recipe = context.Recipes.ToList();
                List<Category> category = context.Categories.ToList();
                List<RecipeIngredient> recipeIngredient = context.RecipeIngredients.ToList();
                List<Ingredient> ingredient = context.Ingredients.ToList();
                var model = from r in recipe
                            join c in category on r.CId equals c.CategoryId into table1
                            from c in table1.DefaultIfEmpty()
                            join ri in recipeIngredient on r.RId equals ri.RId into table2
                            from ri in table2.DefaultIfEmpty()
                            join i in ingredient on ri.InId equals i.InId into table3
                            from i in table3.DefaultIfEmpty()
                            where r.RId == id
                            select new ViewModelRecipe
                            {
                                recipe = r,
                                category = c,
                                recipeingredient = ri,
                                ingredient = i
                            };
                if (model == null)
                {
                    return NotFound();
                }
                return View(model);
            }
        }
        public Recipe GetById(int id)
        {
            return context.Recipes.SingleOrDefault(x => x.RId == id);
        }
    }
    }

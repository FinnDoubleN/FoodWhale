using FoodWhale_User.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWhale_User.Models
{
    public partial class ViewModelRecipe
    {
        public Recipe recipe { get; set; }
        public Category category { get; set; }
        public RecipeIngredient recipeingredient { get; set; }
        public Ingredient ingredient { get; set; }
    }
}

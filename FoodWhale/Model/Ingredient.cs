using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale.Model
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public string InId { get; set; }
        public string InName { get; set; }
        public int Quantity { get; set; }
        public string Price { get; set; }

        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}

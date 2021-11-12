using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale.Models
{
    public partial class Category
    {
        public Category()
        {
            Ingredients = new HashSet<Ingredient>();
            Recipes = new HashSet<Recipe>();
        }

        public int CategoryId { get; set; }
        public string CName { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}

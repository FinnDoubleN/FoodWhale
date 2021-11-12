using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale.Models
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            OrderDetails = new HashSet<OrderDetail>();
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int InId { get; set; }
        public string InName { get; set; }
        public string Image { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }
        public string Guideline { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}

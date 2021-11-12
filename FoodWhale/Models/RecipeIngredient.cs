using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale.Models
{
    public partial class RecipeIngredient
    {
        public int RiId { get; set; }
        public int RId { get; set; }
        public int InId { get; set; }

        public virtual Ingredient In { get; set; }
        public virtual Recipe RIdNavigation { get; set; }

        //@Html.DisplayFor(modelItem => item.In.Description)
    }
}

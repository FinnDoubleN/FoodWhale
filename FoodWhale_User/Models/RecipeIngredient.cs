using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale_User.Models
{
    public partial class RecipeIngredient
    {
        public int Rid { get; set; }
        public string InId { get; set; }

        public virtual Ingredient In { get; set; }
        public virtual Recipe RidNavigation { get; set; }
    }
}

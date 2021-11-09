using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale.Model
{
    public partial class RecipeImage
    {
        public int? Rid { get; set; }
        public string ImageUrl { get; set; }

        public virtual Recipe RidNavigation { get; set; }
    }
}

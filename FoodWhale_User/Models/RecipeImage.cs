using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale_User.Models
{
    public partial class RecipeImage
    {
        public int? Rid { get; set; }
        public string ImageUrl { get; set; }

        public virtual Recipe RidNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale_User.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
        }

        public int Rid { get; set; }
        public string Rname { get; set; }
        public string Rdescription { get; set; }
        public string VideoUrl { get; set; }
        public string Difficulty { get; set; }
        public int Time { get; set; }
        public string Cid { get; set; }
        public int Rating { get; set; }

        public virtual Category CidNavigation { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            RecipeIngredients = new HashSet<RecipeIngredient>();
            RecipeLikes = new HashSet<RecipeLike>();
        }

        public int RId { get; set; }
        public string RName { get; set; }
        public int CId { get; set; }
        public string Image { get; set; }
        public string Difficulty { get; set; }
        public int Time { get; set; }
        public int? LikeCount { get; set; }
        public string RDescription { get; set; }

        public virtual Category CIdNavigation { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual ICollection<RecipeLike> RecipeLikes { get; set; }
    }
}

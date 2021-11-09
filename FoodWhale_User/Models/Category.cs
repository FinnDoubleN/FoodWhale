using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale_User.Models
{
    public partial class Category
    {
        public Category()
        {
            Recipes = new HashSet<Recipe>();
        }

        public string Cid { get; set; }
        public string Cname { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
    }
}

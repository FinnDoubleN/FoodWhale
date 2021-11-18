using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodWhale_User.Models
{
    public partial class ViewModelIngredient
    {
        public Ingredient ingredient { get; set; }
        public Category category { get; set; }
    }
}

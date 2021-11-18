using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodWhale_User.Models;

namespace FoodWhale_User.Models
{
    public partial class ViewModelCart
    {
        public Order order { get; set; }
        public OrderDetail orderdetail { get; set; }
        public Ingredient ingredient { get; set; }
    }
}

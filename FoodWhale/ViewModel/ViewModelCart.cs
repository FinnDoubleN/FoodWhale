using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodWhale.Models;

namespace FoodWhale.ViewModel
{
    public class ViewModelCart
    {
        public Order order { get; set; }
        public OrderDetail orderdetail { get; set; }
    }
}

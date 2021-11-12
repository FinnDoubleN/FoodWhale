using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale_User.Models
{
    public partial class OrderDetail
    {
        public int OdId { get; set; }
        public int OId { get; set; }
        public int InId { get; set; }
        public int Quantity { get; set; }

        public virtual Ingredient In { get; set; }
        public virtual Order OIdNavigation { get; set; }
    }
}

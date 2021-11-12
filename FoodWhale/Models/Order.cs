using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OId { get; set; }
        public int UId { get; set; }
        public DateTime Date { get; set; }
        public bool? Status { get; set; }

        public virtual User UIdNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

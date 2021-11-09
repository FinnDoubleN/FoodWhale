using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale_User.Models
{
    public partial class Order
    {
        public int Oid { get; set; }
        public int Uid { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public virtual User UidNavigation { get; set; }
    }
}

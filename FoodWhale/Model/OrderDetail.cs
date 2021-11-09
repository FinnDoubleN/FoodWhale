using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale.Model
{
    public partial class OrderDetail
    {
        public string Odid { get; set; }
        public int Oid { get; set; }
        public string InId { get; set; }
        public int Quantity { get; set; }

        public virtual Ingredient In { get; set; }
        public virtual Order OidNavigation { get; set; }
    }
}

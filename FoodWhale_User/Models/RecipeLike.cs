using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale_User.Models
{
    public partial class RecipeLike
    {
        public int RlId { get; set; }
        public int RId { get; set; }
        public int UId { get; set; }
        public bool? Fav { get; set; }

        public virtual Recipe RIdNavigation { get; set; }
        public virtual User UIdNavigation { get; set; }
    }
}

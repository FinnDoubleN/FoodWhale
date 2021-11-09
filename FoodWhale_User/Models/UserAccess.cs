using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale_User.Models
{
    public partial class UserAccess
    {
        public string Aid { get; set; }
        public int Uid { get; set; }
        public DateTime DateAccess { get; set; }

        public virtual User UidNavigation { get; set; }
    }
}

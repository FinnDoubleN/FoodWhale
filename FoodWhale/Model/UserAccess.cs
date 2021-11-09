using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale.Model
{
    public partial class UserAccess
    {
        public string Aid { get; set; }
        public int Uid { get; set; }
        public DateTime DateAccess { get; set; }

        public virtual User UidNavigation { get; set; }
    }
}

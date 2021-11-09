using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale.Model
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            UserAccesses = new HashSet<UserAccess>();
        }

        public int Uid { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Uname { get; set; }
        public DateTime? DoB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<UserAccess> UserAccesses { get; set; }
    }
}

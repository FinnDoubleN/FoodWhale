using System;
using System.Collections.Generic;

#nullable disable

namespace FoodWhale.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
            RecipeLikes = new HashSet<RecipeLike>();
        }

        public int UId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UName { get; set; }
        public DateTime? DoB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<RecipeLike> RecipeLikes { get; set; }
    }
}

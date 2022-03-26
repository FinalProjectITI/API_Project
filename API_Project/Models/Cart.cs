using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API_Project.Models
{
    public partial class Cart
    {
        public Cart()
        {
            Orders = new HashSet<Order>();
            ProductInCarts = new HashSet<ProductInCart>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public bool AddedToOrder { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<ProductInCart> ProductInCarts { get; set; }
    }
}

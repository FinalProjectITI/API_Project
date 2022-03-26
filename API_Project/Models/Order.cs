using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API_Project.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int CartId { get; set; }
        public double TotalPrice { get; set; }
        public int Status { get; set; }
        public string Address { get; set; }
        public bool PaymentMethod { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual Cart Cart { get; set; }
    }
}

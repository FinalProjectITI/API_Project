using System;
using System.Collections.Generic;

#nullable disable

namespace API_Project.Models
{
    public partial class ProductInCart
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }

    }
}

using System;
using System.Collections.Generic;

#nullable disable

namespace API_Project.Models
{
    public partial class ProductImage
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }
    }
}

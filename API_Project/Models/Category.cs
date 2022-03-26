using System;
using System.Collections.Generic;

#nullable disable

namespace API_Project.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}

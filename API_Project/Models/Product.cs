using System;
using System.Collections.Generic;

#nullable disable

namespace API_Project.Models
{
    public partial class Product
    {
        public Product()
        {
            Favourits = new HashSet<Favourit>();
            ProductImages = new HashSet<ProductImage>();
            ProductInCarts = new HashSet<ProductInCart>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int Quntity { get; set; }
        public double? Discount { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public int SeasonId { get; set; }
        public bool ShowInHome { get; set; }

        public virtual Category Category { get; set; }
        public virtual Season Season { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<Favourit> Favourits { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductInCart> ProductInCarts { get; set; }
    }
}

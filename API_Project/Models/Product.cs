﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Models
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            Favourits = new HashSet<Favourit>();
            ProductImages = new HashSet<ProductImage>();
            Product_In_Carts = new HashSet<Product_In_Cart>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public double Price { get; set; }
        [Required]
        public string Description { get; set; }
        public int Quntity { get; set; }
        public double? Discount { get; set; }
        public int CategoryID { get; set; }
        public int TypeID { get; set; }
        public int SeasonID { get; set; }
        public bool ShowInHome { get; set; }

        [ForeignKey(nameof(CategoryID))]
        [InverseProperty("Products")]
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(SeasonID))]
        [InverseProperty("Products")]
        public virtual Season Season { get; set; }
        [ForeignKey(nameof(TypeID))]
        [InverseProperty("Products")]
        public virtual Type Type { get; set; }
        [InverseProperty(nameof(Favourit.Product))]
        public virtual ICollection<Favourit> Favourits { get; set; }
        [InverseProperty(nameof(ProductImage.Product))]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        [InverseProperty(nameof(Product_In_Cart.Product))]
        public virtual ICollection<Product_In_Cart> Product_In_Carts { get; set; }
    }
}
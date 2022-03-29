﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Models
{
    [Table("Type")]
    public partial class Type
    {
        public Type()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        public string ImagePath { get; set; }

        [InverseProperty(nameof(Product.Type))]
        public virtual ICollection<Product> Products { get; set; }
    }
}
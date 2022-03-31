﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Models
{
    [Table("Season")]
    public partial class Season
    {
        public Season()
        {
            Products = new HashSet<Product>();
        }

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [InverseProperty(nameof(Product.Season))]
        public virtual ICollection<Product> Products { get; set; }

        public static explicit operator string(Season v)
        {
            throw new NotImplementedException();
        }
    }
}
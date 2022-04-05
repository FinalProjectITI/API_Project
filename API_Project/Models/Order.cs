﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace API_Project.Models
{
    [Table("Order")]
    public partial class Order
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(450)]
        public string UserID { get; set; }
        public int CartID { get; set; }
        public double TotalPrice { get; set; }
        public int status { get; set; }
        [Required]
        public string Address { get; set; }
        public bool PaymentMethod { get; set; }

        [ForeignKey(nameof(CartID))]
        [InverseProperty("Orders")]
        [JsonIgnore]
        public virtual Cart Cart { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(UserID))]
        [InverseProperty(nameof(AspNetUser.Orders))]
        public virtual AspNetUser User { get; set; }
    }
}
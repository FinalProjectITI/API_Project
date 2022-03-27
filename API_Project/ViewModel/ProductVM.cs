using API_Project.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.ViewModel
{
    public class ProductVM
    {
        public ProductVM()
        {
            
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
        public string Category { get; set; }
        public string Type { get; set; }
        public string Season { get; set; }
        public bool ShowInHome { get; set; }

        public List<string> Images { get; set; }
    }
}

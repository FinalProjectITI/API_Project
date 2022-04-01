using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.ViewModel
{
    public class CartDetalisMV
    {
        public List <ProductVM> ProductsVCart {get;set;}
        public int TotalCartPrice { get; set; }
    }
}

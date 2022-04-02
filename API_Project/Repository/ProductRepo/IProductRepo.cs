using API_Project.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Repository
{
   public interface IProductRepo
    {

        Task<ActionResult<IEnumerable<ProductVM>>> GetProducts(int start, int categoryId);
        Task<ActionResult<IEnumerable<ProductVM>>> GetProductsInHome();
        Task<ActionResult<IEnumerable<ProductVM>>> GetSearchResult(string searchKey,int start);
        Task<ActionResult<ProductVM>> GetProduct(int id);
        Task<ActionResult<IEnumerable<ProductVM>>> GetSimilarProducts(int typeId, int categoryId, int productId);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Project.Models;
using AutoMapper;
using API_Project.ViewModel;
using API_Project.Repository;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepo _productRepo;
       public ProductsController(IProductRepo productRepo,AlaslyFactoryContext context, IMapper mapper)
        {
            _productRepo = productRepo;
        }

        // GET: api/Products
        [Route("GetProducts/{start}/{categoryId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProducts(int start,int categoryId)
        {
            return await _productRepo.GetProducts(start,categoryId);
           
        }

        //[Route("GetInHome/{start}/{categoryId}")]
        [Route("GetInHome")]
        [HttpGet]

        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProductsInHome()
        {
            return await _productRepo.GetProductsInHome();
            //return await _context.Products.Where(p => p.ShowInHome == true).ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVM>> GetProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);


                if (product == null)
                {
                    return NotFound();
                }

                ProductVM productVM = _mapper.Map<ProductVM>(product);

                productVM.Images = await _context.ProductImages
                    .Where(P => P.ProductID == product.ID)
                    .Select(p => p.ImagePath).ToListAsync();
                productVM.Category = _context.Categories.Find(product.CategoryID).Name;
                productVM.Type = _context.Types.Find(product.TypeID).Name;
                productVM.Season = _context.Seasons.Find(product.SeasonID).Name;


                return productVM;
            }
            catch (Exception)
            {

                throw;
            }
        }

        #region Extra
        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProduct(int id, Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        //--------------------
        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Product>> PostProduct(Product product)
        //{
        //    _context.Products.Add(product);
        //    await _context.SaveChangesAsync();

        
        //private bool ProductExists(int id)
        //{
        //    return _context.Products.Any(e => e.ID == id);
        //}
    }
}

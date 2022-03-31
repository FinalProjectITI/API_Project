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

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly AlaslyFactoryContext _context;

        public ProductsController(AlaslyFactoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Products
        [Route("GetProducts/{start}/{categoryId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProducts(int start,int categoryId)
        {
            try
            {
                List<ProductVM> ProductsWithImage = new List<ProductVM>();
                List<Product> products = await _context.Products.Where(P => P.CategoryID == categoryId)
                    .Skip(start).Take(20).ToListAsync();
                if (products != null)
                {
                    foreach (var product in products)
                    {
                        ProductVM productVM = _mapper.Map<ProductVM>(product);

                        productVM.FirstImage = _context.ProductImages
                            .Where(P => P.ProductID == product.ID)
                            .Select(p => p.ImagePath).FirstOrDefault();
                        productVM.Category = _context.Categories.Find(product.CategoryID).Name;
                        productVM.Type = _context.Types.Find(product.TypeID).Name;
                        productVM.Season = _context.Seasons.Find(product.SeasonID).Name;

                        ProductsWithImage.Add(productVM);
                    }
                    return ProductsWithImage;
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
        }

        //[Route("GetInHome/{start}/{categoryId}")]
        [Route("GetInHome")]
        [HttpGet]

        //        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProductsInHome(int start, int categoryId)
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProductsInHome()
        {
            try
            {
                List<ProductVM> ProductsWithImage = new List<ProductVM>();
                List<Product> products = await _context.Products
                    .Where(P=> P.ShowInHome == true).ToListAsync();
                //.Skip(start).Take(20).ToListAsync();

                if (products != null)
                {
                    foreach (var product in products)
                    {
                        ProductVM productVM = _mapper.Map<ProductVM>(product);

                        productVM.FirstImage = _context.ProductImages
                            .Where(P => P.ProductID == product.ID)
                            .Select(p => p.ImagePath).FirstOrDefault();
                        productVM.Category = _context.Categories.Find(product.CategoryID).Name;
                        productVM.Type = _context.Types.Find(product.TypeID).Name;
                        productVM.Season = _context.Seasons.Find(product.SeasonID).Name;

                        ProductsWithImage.Add(productVM);
                    }
                    return ProductsWithImage;
                }
                else
                    return NotFound();
            }
            catch (Exception)
            {

                throw;
            }
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

        //    return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        //}

        // DELETE: api/Products/5
        //------
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteProduct(int id)
        //{
        //    var product = await _context.Products.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Products.Remove(product);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //} 
        #endregion

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ID == id);
        }
    }
}

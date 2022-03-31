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
        public ProductsController(IProductRepo productRepo, AlaslyFactoryContext context, IMapper mapper)
        {
            _productRepo = productRepo;
        }

        // GET: api/Products
        [Route("GetProducts/{start}/{categoryId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProducts(int start, int categoryId)
        {
            return await _productRepo.GetProducts(start, categoryId);

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
            return await _productRepo.GetProduct(id);
           
        }
        [Route("GetSimilar/{typeId}/{categoryId}/{productId}")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVM>>> GetSimilarProducts(int typeId, int categoryId, int productId)
        {
            return await _productRepo.GetSimilarProducts(typeId, categoryId, productId);
        }
    }
    }


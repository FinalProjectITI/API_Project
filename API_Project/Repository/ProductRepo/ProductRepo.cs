using API_Project.Models;
using API_Project.ViewModel;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Project.Repository.ProductRepo
{
    public class ProductRepo : IProductRepo
    {
        private readonly AlaslyFactoryContext _context;
        private readonly IMapper _mapper;
        public ProductRepo(AlaslyFactoryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
    }
        public async Task<ActionResult<ProductVM>> GetProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);


                if (product == null)
                {
                    return new NotFoundResult();
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

        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProducts(int start, int categoryId)
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
                    return new NotFoundResult();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ActionResult<IEnumerable<ProductVM>>> GetProductsInHome()
        {
            try
            {
                List<ProductVM> ProductsWithImage = new List<ProductVM>();
                List<Product> products = await _context.Products
                    .Where(P => P.ShowInHome == true).ToListAsync();
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
                    return new NotFoundResult();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ActionResult<IEnumerable<ProductVM>>> GetSearchResult(string searchKey,int start)
        {

            try
            {
                List<ProductVM> ProductsWithImage = new List<ProductVM>();
                List<Product> products = await _context.Products
                    .Where(P => P.Name.Contains(searchKey) )
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
                    return new NotFoundResult();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using API_Project.Models;
using Microsoft.AspNetCore.Authorization;
using API_Project.ViewModel;
using System.Security.Claims;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CartsController : ControllerBase
    {
        private AlaslyFactoryContext _context;

        public CartsController(AlaslyFactoryContext context)
        {
            _context = context;
        }

        // GET: api/Cart
        [HttpGet]
        [Route("GETCart")]
        public ActionResult<CartDetalisMV> GetCart()
        {
            try
            {

                string user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Cart Cart1 = _context.Carts.FirstOrDefault(C => C.UserID == user_id);
                int CartIDD = Cart1.ID;
                var ListOfProduct = _context.Product_In_Carts.Where(p => p.CartID == CartIDD).ToList();
                CartDetalisMV cartview = new CartDetalisMV();
                cartview.TotalCartPrice = 0;
                foreach (var item in ListOfProduct)
                {
                    
                    ProductVM productVMM = new ProductVM();
                    productVMM.Quntity = item.quantity;
                    productVMM.Price = item.Product.Price;
                    productVMM.Name = item.Product.Name;
                    productVMM.ID = item.Product.ID;
                    productVMM.Images = (List<string>)item.Product.ProductImages;
                    productVMM.Category = item.Product.Category.Name;
                    productVMM.Season = item.Product.Season.Name;

                    

                    //product should appear on cart
                    ProductCartMV productCartMVV = new ProductCartMV();
                    productCartMVV.ProductVM = productVMM;
                    productCartMVV.QuntityOfProduct = productVMM.Quntity;
                    productCartMVV.TotalPrice = (int)(productCartMVV.QuntityOfProduct * productVMM.Price);
                 

                    //cart detalis vew
                    cartview.TotalCartPrice = 2000;
                    cartview.ProductsVCart.Add(productCartMVV);


                }

                return cartview;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see
        //////////////////******************************UPDATE function**************************************************
        [HttpPut]
        [Route("UpdateCart")]
        public IActionResult PutCart([FromBody] List<ProductIds> UpdatingProduct)
        {

            string user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Cart Cart1 = _context.Carts.FirstOrDefault(C => C.UserID == user_id);
            int CartIDD = Cart1.ID;
            foreach (var item in UpdatingProduct)
            {
                var ProductOfCart = _context.Product_In_Carts.Where(p => p.ProductID == item.ProductID && p.CartID == CartIDD).FirstOrDefault();
                if (item.Quntity > 0)
                {
                    ProductOfCart.quantity = item.Quntity;
                    _context.SaveChanges();
                }
                else
                    return BadRequest(new Response { Status = "Erro", Message = "quntity no valid successfully!" });
            }



            return Ok(new Response { Status = "Success", Message = "product added successfully!" });
        }
        //********************************************ADD TO CART FUNCTION**********************************************************
        // POST: api/Carts

        [HttpPost("{id}")]

        public async Task<ActionResult> PostToCart(int Product_id)
        {
            try
            {
                string user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Cart Cart1 = _context.Carts.FirstOrDefault(C => C.UserID == user_id);

                #region extra
                //        if (Cart1 == null)
                //        {
                //            Cart NewCart = new Cart() { UserID = Cart1.UserID };
                //            _context.Carts.Add(Cart1);
                //            await _context.SaveChangesAsync();
                //            Cart1.UserID = NewCart.UserID;
                //            Cart1.ID = NewCart.ID;
                //        }
                //        Product ProductAdded = _context.Products.FirstOrDefault(p => p.ID == Product_id);
                //        if (ProductAdded == null)
                //        {
                //            return BadRequest(new Response { Status = "Error", Message = "product Null!" });
                //        }
                //        ProductInCart P = new ProductInCart()
                //        {
                //            CartId = Cart1.ID,
                //            Quantity = 1

                //}; 
                #endregion
                return Ok(new Response { Status = "Success", Message = "product added successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        //}
        ////****************************************DELETE FROM CART FUNCTION*************************************************************************

        // DELETE: api/Carts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFromCart(int Product_id)
        {

            try
            {
                string user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                Cart Cart1 = _context.Carts.FirstOrDefault(C => C.UserID == user_id);
                int CartIDD = Cart1.ID;
                var ProductOfCart = _context.Product_In_Carts.Where(p => p.ProductID == Product_id && p.CartID == CartIDD).FirstOrDefault();
                _context.Product_In_Carts.Remove(ProductOfCart);

                await _context.SaveChangesAsync();

                return Ok(new Response { Status = "Success", Message = "product removed from cart successfully!" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        ////***********************************************************Delete CART***************************************************************************
        [HttpDelete]
            public IActionResult DeleteCart()
            {

                try
                {
                    string user_id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                    Cart Cart1 = _context.Carts.FirstOrDefault(C => C.UserID == user_id);
                    int CartIDD = Cart1.ID;
                    var ProductsOfCart = _context.Product_In_Carts.Where(d => d.CartID == CartIDD).ToList();
                    foreach (var ProductItem in ProductsOfCart)
                    {
                        _context.Product_In_Carts.Remove(ProductItem);


                    }
                    _context.SaveChanges();


                    return Ok(new Response { Status = "Success", Message = "cart Deleted successfully!" });
                }

                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }

            }

        }


}
    

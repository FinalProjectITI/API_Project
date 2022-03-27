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

        // GET: api/Carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _context.Carts.ToListAsync();
        }

        // GET: api/Carts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            var cart = await _context.Carts.FindAsync(id);

            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // PUT: api/Carts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        ////////////////////******************************UPDATE function**************************************************
        //[HttpPut]
        //public  IActionResult PutCart([FromBody] List<ProductIds> UpdatingProduct)
        //{
            
        //    string User_id = User.Identity.GetUserId();
        //    Cart Cart1 =  _context.Carts.FirstOrDefault(C => C.UserID == User_id);
        //   int CartIDD = Cart1.ID;
        //    foreach( var item in UpdatingProduct)
        //    {
        //        var ProductOfCart = _context.Product_In_Carts.Where(p => p.ProductID == item.ProductID && p.CartID == CartIDD).FirstOrDefault();
        //        if (item.Quntity > 0)
        //        {
        //            ProductOfCart.quantity = item.Quntity;
        //             _context.SaveChanges();
        //        } 
        //        else
        //            return BadRequest(new Response { Status = "Erro", Message = "quntity no valid successfully!" });
        //    }



        //    //if (id != cart.ID)
        //    //{
        //    //    return BadRequest();
        //    //}

        //    //_context.Entry(cart).State = EntityState.Modified;

        //    //try
        //    //{
        //    //    await _context.SaveChangesAsync();
        //    //}
        //    //catch (DbUpdateConcurrencyException)
        //    //{
        //    //    if (!CartExists(id))
        //    //    {
        //    //        return NotFound();
        //    //    }
        //    //    else
        //    //    {
        //    //        throw;
        //    //    }
        //    //}

        //    return Ok(new Response { Status = "Success", Message = "product added successfully!" });
        //}
        ////********************************************ADD TO CART FUNCTION**********************************************************
        //// POST: api/Carts
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost("{id}")]
        //public async Task<ActionResult> PostToCart(int Product_id)
        //{
        //    try
        //    {
        //        string User_id = User.Identity.GetUserId();
        //        Cart Cart1 = _context.Carts.FirstOrDefault(C => C.UserID == User_id);

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

        //        };
        //        return Ok(new Response { Status = "Success", Message = "product added successfully!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }



        //}
        ////****************************************DELETE FROM CART FUNCTION*************************************************************************

        //// DELETE: api/Carts/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteFromCart(int Product_id)
        //{

        //    try
        //    {
        //        string User_id = User.Identity.GetUserId();
        //        Cart Cart1 = _context.Carts.FirstOrDefault(C => C.UserID == User_id);
        //        int CartIDD = Cart1.ID;
        //        var ProductOfCart = _context.Product_In_Carts.Where(p => p.ProductID == Product_id && p.CartID == CartIDD).FirstOrDefault();
        //        _context.Product_In_Carts.Remove(ProductOfCart);

        //        await _context.SaveChangesAsync();

        //        return Ok(new Response { Status = "Success", Message = "product removed from cart successfully!" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }


        //}
        ////***********************************************************Delete CART***************************************************************************
        //[HttpDelete]
        //public  IActionResult DeleteCart()
        //{

        //    try
        //    {
        //        string User_id = User.Identity.GetUserId();
        //        Cart Cart1 = _context.Carts.FirstOrDefault(C => C.UserID == User_id);
        //        int CartIDD = Cart1.ID;
        //        var ProductsOfCart = _context.Product_In_Carts.Where(d => d.CartID == CartIDD).ToList();
        //        foreach (var ProductItem in ProductsOfCart)
        //        {
        //            _context.Product_In_Carts.Remove(ProductItem);


        //        }
        //        _context.SaveChanges();


        //        return Ok(new Response { Status = "Success", Message = "cart Deleted successfully!" });
        //    }

        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }

        //}
    
    }


}
    

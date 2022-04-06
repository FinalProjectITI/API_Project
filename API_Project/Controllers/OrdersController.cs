﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Project.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using API_Project.ViewModel;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrdersController : ControllerBase
    {
        private readonly AlaslyFactoryContext _context;

        public OrdersController(AlaslyFactoryContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            string UserName = User.FindFirstValue(ClaimTypes.Name);
            var user_id = _context.AspNetUsers.Where(U => U.UserName == UserName).Select(U => U.Id).FirstOrDefault();
            return await _context.Orders.Where(o=>o.UserID=="1"&&o.status==1||o.status==2||o.status==0).ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        //public async Task<ActionResult<Order>> GetOrder(int id)
        //{
        //    var order = await _context.Orders.FindAsync(id);

        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    return order;
        //}

        // PUT: api/Orders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrder(int id, Order order)
        //{
        //    if (id != order.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            string UserName = User.FindFirstValue(ClaimTypes.Name);
            var user_id = _context.AspNetUsers.Where(U => U.UserName == UserName).Select(U => U.Id).FirstOrDefault();
            order.status = 1;
            order.UserID = user_id;
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return Ok("Added Succefuly");
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order.status == 2)
                return BadRequest("Not allowed");
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.ID == id);
        }
    }
}

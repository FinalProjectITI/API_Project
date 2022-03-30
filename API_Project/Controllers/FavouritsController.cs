using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Project.Models;
using Microsoft.AspNetCore.Authorization;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouritsController : ControllerBase
    {
        private readonly AlaslyFactoryContext _context;

        public FavouritsController(AlaslyFactoryContext context)
        {
            _context = context;
        }

        // GET: api/Favourits
        [HttpGet]
  
        public async Task<IEnumerable<Favourit>> GetFavourits()
        {
            
            return await _context.Favourits.ToListAsync();
        }

        // GET: api/Favourits/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Favourit>> GetFavourit(int id)
        //{
        //    var favourit = await _context.Favourits.FindAsync(id);

        //    if (favourit == null)
        //    {
        //        return NotFound();
        //    }

        //    return favourit;
        //}

        // PUT: api/Favourits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       // [HttpPut("{id}")]
        

        // POST: api/Favourits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Favourit>> PostFavourit(Favourit favourit)
        {
            _context.Favourits.Add(favourit);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (FavouritExists(favourit.ProductID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetFavourit", new { id = favourit.ProductID }, favourit);
        }

        // DELETE: api/Favourits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavourit(int id)
        {
            var favourit = await _context.Favourits.FindAsync(id);
            if (favourit == null)
            {
                return NotFound();
            }

            _context.Favourits.Remove(favourit);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavouritExists(int id)
        {
            return _context.Favourits.Any(e => e.ProductID == id);
        }
    }
}

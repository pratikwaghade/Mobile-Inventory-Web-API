using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mobile_Inventory_Web_API.Data;
using Mobile_Inventory_Web_API.Model;

namespace Mobile_Inventory_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobilesController : ControllerBase
    {
        private readonly MobileContext _context;

        public MobilesController(MobileContext context)
        {
            _context = context;
        }

        // GET: api/Mobiles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mobile>>> GetMobiles()
        {
            return await _context.Mobiles.ToListAsync();
        }

        // GET: api/Mobiles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mobile>> GetMobile(int id)
        {
            var mobile = await _context.Mobiles.FindAsync(id);

            if (mobile == null)
            {
                return NotFound();
            }

            return mobile;
        }

        // PUT: api/Mobiles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobile(int id, Mobile mobile)
        {
            if (id != mobile.Id)
            {
                return BadRequest();
            }

            _context.Entry(mobile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mobiles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Mobile>> PostMobile(Mobile mobile)
        {
            _context.Mobiles.Add(mobile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobile", new { id = mobile.Id }, mobile);
        }

        // DELETE: api/Mobiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMobile(int id)
        {
            var mobile = await _context.Mobiles.FindAsync(id);
            if (mobile == null)
            {
                return NotFound();
            }

            _context.Mobiles.Remove(mobile);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MobileExists(int id)
        {
            return _context.Mobiles.Any(e => e.Id == id);
        }
    }
}

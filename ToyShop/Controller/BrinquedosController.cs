using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToyStore.Data;
using ToyStore.Models;

namespace ToyStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrinquedosController : ControllerBase
    {
        private readonly ToyStoreContext _context;

        public BrinquedosController(ToyStoreContext context)
        {
            _context = context;
        }

        // GET /brinquedos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brinquedo>>> GetBrinquedos()
        {
            return await _context.Brinquedos.ToListAsync();
        }

        // GET /brinquedos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Brinquedo>> GetBrinquedo(int id)
        {
            var brinquedo = await _context.Brinquedos.FindAsync(id);
            if (brinquedo == null)
                return NotFound();

            return brinquedo;
        }

        // POST /brinquedos
        [HttpPost]
        public async Task<ActionResult<Brinquedo>> PostBrinquedo(Brinquedo brinquedo)
        {
            _context.Brinquedos.Add(brinquedo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBrinquedo), new { id = brinquedo.Id_brinquedo }, brinquedo);
        }

        // PUT /brinquedos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBrinquedo(int id, Brinquedo brinquedo)
        {
            if (id != brinquedo.Id_brinquedo)
                return BadRequest();

            _context.Entry(brinquedo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Brinquedos.Any(b => b.Id_brinquedo == id))
                    return NotFound();
                throw;
            }

            return Ok(brinquedo);
        }

        // DELETE /brinquedos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrinquedo(int id)
        {
            var brinquedo = await _context.Brinquedos.FindAsync(id);
            if (brinquedo == null)
                return NotFound();

            _context.Brinquedos.Remove(brinquedo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
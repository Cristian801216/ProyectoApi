using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AplicacionAgricola.Context;
using AplicacionAgricola.Models;

namespace AplicacionAgricola.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FincasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FincasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Fincas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fincas>>> GetFincas()
        {
            return await _context.Fincas.ToListAsync();
        }

        // GET: api/Fincas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Fincas>> GetFincas(int id)
        {
            var fincas = await _context.Fincas.FindAsync(id);

            if (fincas == null)
            {
                return NotFound();
            }

            return fincas;
        }

        // PUT: api/Fincas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFincas(int id, Fincas fincas)
        {
            if (id != fincas.Id)
            {
                return BadRequest();
            }

            _context.Entry(fincas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FincasExists(id))
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

        // POST: api/Fincas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Fincas>> PostFincas(Fincas fincas)
        {
            _context.Fincas.Add(fincas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFincas", new { id = fincas.Id }, fincas);
        }

        // DELETE: api/Fincas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFincas(int id)
        {
            var fincas = await _context.Fincas.FindAsync(id);
            if (fincas == null)
            {
                return NotFound();
            }

            _context.Fincas.Remove(fincas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FincasExists(int id)
        {
            return _context.Fincas.Any(e => e.Id == id);
        }
    }
}

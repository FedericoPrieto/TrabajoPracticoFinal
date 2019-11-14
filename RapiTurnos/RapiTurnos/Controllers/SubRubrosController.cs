using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapiTurnos.Models;

namespace RapiTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubRubrosController : ControllerBase
    {
        private readonly TurnosWebContext _context;

        public SubRubrosController(TurnosWebContext context)
        {
            _context = context;
        }

        // GET: api/SubRubros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubRubros>>> GetSubRubros()
        {
            return await _context.SubRubros.ToListAsync();
        }

        // GET: api/SubRubros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubRubros>> GetSubRubros(int id)
        {
            var subRubros = await _context.SubRubros.FindAsync(id);

            if (subRubros == null)
            {
                return NotFound();
            }

            return subRubros;
        }


        [HttpGet]
        [Route("/api/SubRubros/GetSubRubrosByRubroID/{RubroID}")]
        public async Task<ActionResult<IEnumerable<SubRubros>>> GetSubRubrosByRubroID(short RubroID)
        {
            return await _context.SubRubros
                .Where(s => s.RubroId == RubroID)
                .ToListAsync();
            
        }




        // PUT: api/SubRubros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubRubros(int id, SubRubros subRubros)
        {
            if (id != subRubros.SubRubroId)
            {
                return BadRequest();
            }

            _context.Entry(subRubros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubRubrosExists(id))
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

        // POST: api/SubRubros
        [HttpPost]
        public async Task<ActionResult<SubRubros>> PostSubRubros(SubRubros subRubros)
        {
            _context.SubRubros.Add(subRubros);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubRubros", new { id = subRubros.SubRubroId }, subRubros);
        }

        // DELETE: api/SubRubros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SubRubros>> DeleteSubRubros(int id)
        {
            var subRubros = await _context.SubRubros.FindAsync(id);
            if (subRubros == null)
            {
                return NotFound();
            }

            _context.SubRubros.Remove(subRubros);
            await _context.SaveChangesAsync();

            return subRubros;
        }

        private bool SubRubrosExists(int id)
        {
            return _context.SubRubros.Any(e => e.SubRubroId == id);
        }
    }
}

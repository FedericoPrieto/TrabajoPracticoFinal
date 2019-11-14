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
    public class LocalidadesController : ControllerBase
    {
        private readonly TurnosWebContext _context;

        public LocalidadesController(TurnosWebContext context)
        {
            _context = context;
        }

        // GET: api/Localidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localidades>>> GetLocalidades()
        {
            return await _context.Localidades.ToListAsync();
        }

        // GET: api/Localidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Localidades>> GetLocalidades(short id)
        {
            var localidades = await _context.Localidades.FindAsync(id);

            if (localidades == null)
            {
                return NotFound();
            }

            return localidades;
        }

        // PUT: api/Localidades/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalidades(short id, Localidades localidades)
        {
            if (id != localidades.IdLocalidad)
            {
                return BadRequest();
            }

            _context.Entry(localidades).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalidadesExists(id))
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

        // POST: api/Localidades
        [HttpPost]
        public async Task<ActionResult<Localidades>> PostLocalidades(Localidades localidades)
        {
            _context.Localidades.Add(localidades);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalidades", new { id = localidades.IdLocalidad }, localidades);
        }

        // DELETE: api/Localidades/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Localidades>> DeleteLocalidades(short id)
        {
            var localidades = await _context.Localidades.FindAsync(id);
            if (localidades == null)
            {
                return NotFound();
            }

            _context.Localidades.Remove(localidades);
            await _context.SaveChangesAsync();

            return localidades;
        }

        private bool LocalidadesExists(short id)
        {
            return _context.Localidades.Any(e => e.IdLocalidad == id);
        }
    }
}

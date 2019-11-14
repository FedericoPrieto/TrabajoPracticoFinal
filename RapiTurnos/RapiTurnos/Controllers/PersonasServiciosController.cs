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
    public class PersonasServiciosController : ControllerBase
    {
        private readonly TurnosWebContext _context;

        public PersonasServiciosController(TurnosWebContext context)
        {
            _context = context;
        }

        // GET: api/PersonasServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonasServicios>>> GetPersonasServicios()
        {
            return await _context.PersonasServicios.ToListAsync();
        }

        // GET: api/PersonasServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonasServicios>> GetPersonasServicios(int id)
        {
            var personasServicios = await _context.PersonasServicios.FindAsync(id);

            if (personasServicios == null)
            {
                return NotFound();
            }

            return personasServicios;
        }

        // PUT: api/PersonasServicios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonasServicios(int id, PersonasServicios personasServicios)
        {
            if (id != personasServicios.IdPersonaServicio)
            {
                return BadRequest();
            }

            _context.Entry(personasServicios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonasServiciosExists(id))
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

        // POST: api/PersonasServicios
        [HttpPost]
        public async Task<ActionResult<PersonasServicios>> PostPersonasServicios(PersonasServicios personasServicios)
        {
            _context.PersonasServicios.Add(personasServicios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonasServicios", new { id = personasServicios.IdPersonaServicio }, personasServicios);
        }

        // DELETE: api/PersonasServicios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<PersonasServicios>> DeletePersonasServicios(int id)
        {
            var personasServicios = await _context.PersonasServicios.FindAsync(id);
            if (personasServicios == null)
            {
                return NotFound();
            }

            _context.PersonasServicios.Remove(personasServicios);
            await _context.SaveChangesAsync();

            return personasServicios;
        }

        private bool PersonasServiciosExists(int id)
        {
            return _context.PersonasServicios.Any(e => e.IdPersonaServicio == id);
        }
    }
}

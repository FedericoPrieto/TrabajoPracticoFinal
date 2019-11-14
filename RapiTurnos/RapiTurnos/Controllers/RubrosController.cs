using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapiTurnos.Models;
using RapiTurnosDTO.DTOs;

namespace RapiTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RubrosController : ControllerBase
    {
        private readonly TurnosWebContext _context;

        public RubrosController(TurnosWebContext context)
        {
            _context = context;
        }

        // GET: api/Rubros
        [HttpGet]
        public async Task<ActionResult<List<RubrosDTO>>> GetRubros()
        {
            //return await _context.Rubros.ToListAsync();
            var models = _context.Rubros;
            var dtos = Mapper.Map<IEnumerable<RubrosDTO>>(models);
            return Ok(dtos);
        }

        // GET: api/Rubros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rubros>> GetRubros(short id)
        {
            var rubros = await _context.Rubros.FindAsync(id);

            if (rubros == null)
            {
                return NotFound();
            }

            return rubros;
        }

        // PUT: api/Rubros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRubros(short id, Rubros rubros)
        {
            if (id != rubros.RubroId)
            {
                return BadRequest();
            }

            _context.Entry(rubros).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RubrosExists(id))
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

        // POST: api/Rubros
        [HttpPost]
        public async Task<ActionResult<Rubros>> PostRubros(Rubros rubros)
        {
            _context.Rubros.Add(rubros);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (RubrosExists(rubros.RubroId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetRubros", new { id = rubros.RubroId }, rubros);
        }

        // DELETE: api/Rubros/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rubros>> DeleteRubros(short id)
        {
            var rubros = await _context.Rubros.FindAsync(id);
            if (rubros == null)
            {
                return NotFound();
            }

            _context.Rubros.Remove(rubros);
            await _context.SaveChangesAsync();

            return rubros;
        }

        private bool RubrosExists(short id)
        {
            return _context.Rubros.Any(e => e.RubroId == id);
        }
    }
}

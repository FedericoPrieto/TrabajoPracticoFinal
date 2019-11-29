using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapiTurnos.Models;
using RapiTurnos.DTOs;
using AutoMapper;
using RapiTurnosDTO.DTOs;

namespace RapiTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DuracionTurnosController : ControllerBase
    {
        private readonly TurnosWebContext _context;

        public DuracionTurnosController(TurnosWebContext context)
        {
            _context = context;
        }

        // GET: api/DuracionTurnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DuracionTurnosDTO>>> GetDuracionTurnos()
        //public IEnumerable<DuracionTurnosDTO> GetDuracionTurnos()
        {
            //_context.Database.ExecuteSqlCommand("sploco")

            //return await _context.DuracionTurnos.ToListAsync();
            var models = _context.DuracionTurnos;
            var dtos = Mapper.Map<IEnumerable<DuracionTurnosDTO>>(models);
            
            return await Task.Run(() => Ok(dtos));
        }

        // GET: api/DuracionTurnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DuracionTurnos>> GetDuracionTurnos(short id)
        {
            var duracionTurnos = await _context.DuracionTurnos.FindAsync(id);

            if (duracionTurnos == null)
            {
                return NotFound();
            }

            return duracionTurnos;
        }

        // PUT: api/DuracionTurnos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDuracionTurnos(short id, DuracionTurnos duracionTurnos)
        {
            if (id != duracionTurnos.IdDuracionTurno)
            {
                return BadRequest();
            }

            _context.Entry(duracionTurnos).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DuracionTurnosExists(id))
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

        // POST: api/DuracionTurnos
        [HttpPost]
        public async Task<ActionResult<DuracionTurnos>> PostDuracionTurnos(DuracionTurnos duracionTurnos)
        {

            if (duracionTurnos.IdDuracionTurno==0)
            {
                short intIdt=_context.DuracionTurnos.Max(u => u.IdDuracionTurno);
                intIdt += 1;
                duracionTurnos.IdDuracionTurno  = intIdt;
            }

            _context.DuracionTurnos.Add(duracionTurnos);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (DuracionTurnosExists(duracionTurnos.IdDuracionTurno)  )
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDuracionTurnos", new { id = duracionTurnos.IdDuracionTurno }, duracionTurnos);
        }

        // DELETE: api/DuracionTurnos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<DuracionTurnos>> DeleteDuracionTurnos(short id)
        {
            var duracionTurnos = await _context.DuracionTurnos.FindAsync(id);
            if (duracionTurnos == null)
            {
                return NotFound();
            }

            _context.DuracionTurnos.Remove(duracionTurnos);
            await _context.SaveChangesAsync();

            return duracionTurnos;
        }

        private bool DuracionTurnosExists(short id)
        {
            return _context.DuracionTurnos.Any(e => e.IdDuracionTurno == id);
        }
    }
}

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
    public class EmpresasServiciosController : ControllerBase
    {
        private readonly TurnosWebContext _context;

        public EmpresasServiciosController(TurnosWebContext context)
        {
            _context = context;
        }

        // GET: api/EmpresasServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpresasServicios>>> GetEmpresasServicios()
        {
            return await _context.EmpresasServicios.ToListAsync();
        }



        
        [HttpGet]
        [Route("/api/EmpresasServicios/GetEmpresasServiciosByEmpresa/{IdEmpresa}")]
        public async Task<ActionResult<IEnumerable<EmpresasServicios>>> GetEmpresasServiciosByEmpresa(int idEmpresa)
        {
            return await _context.EmpresasServicios
                .Include(x => x.IdDuracionTurnoNavigation)
                .Where(s => s.IdEmpresa == idEmpresa)
                .ToListAsync();
                //como hago para devolver la descripcion de IdDuracionTurno romero
        }



        // GET: api/EmpresasServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpresasServicios>> GetEmpresasServicios(short id)
        {
            var empresasServicios = await _context.EmpresasServicios.FindAsync(id);

            if (empresasServicios == null)
            {
                return NotFound();
            }

            return empresasServicios;
        }

        // PUT: api/EmpresasServicios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresasServicios(short id, EmpresasServicios empresasServicios)
        {
            if (id != empresasServicios.IdServicio)
            {
                return BadRequest();
            }

            _context.Entry(empresasServicios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresasServiciosExists(id))
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

        // POST: api/EmpresasServicios
        [HttpPost]
        public async Task<ActionResult<EmpresasServicios>> PostEmpresasServicios(EmpresasServicios empresasServicios)
        {
            _context.EmpresasServicios.Add(empresasServicios);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresasServicios", new { id = empresasServicios.IdServicio }, empresasServicios);
        }

        // DELETE: api/EmpresasServicios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EmpresasServicios>> DeleteEmpresasServicios(short id)
        {
            var empresasServicios = await _context.EmpresasServicios.FindAsync(id);
            if (empresasServicios == null)
            {
                return NotFound();
            }

            _context.EmpresasServicios.Remove(empresasServicios);
            await _context.SaveChangesAsync();

            return empresasServicios;
        }

        private bool EmpresasServiciosExists(short id)
        {
            return _context.EmpresasServicios.Any(e => e.IdServicio == id);
        }
    }
}

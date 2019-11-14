using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapiTurnos.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using RapiTurnos.Services;
using RapiTurnosDTO.DTOs;
using AutoMapper;

namespace RapiTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly TurnosWebContext _context;

        public EmpresasController(TurnosWebContext context)
        {
            _context = context;
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresas>>> GetEmpresas()
        {
            return await _context.Empresas.ToListAsync();
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresas>> GetEmpresas(int id)
        {
            var empresas = await _context.Empresas.FindAsync(id);

            if (empresas == null)
            {
                return NotFound();
            }

            return empresas;
        }

        // HttpOptions: api/Empresas/juan@gmail.com

        //[HttpGet("{mail}")]
        [HttpGet]
        [Route("/api/Empresas/GetEmpresasByMail/{mail}")]
        // ROMERO tuve que poner HttpOptions porque me hacia conflicto con el anterior
        public async Task<ActionResult<EmpresasDTO>> GetEmpresasByMail(string mail)
        {
            var empresa = _context.Empresas.Single(s => s.Email == mail);

            if (empresa == null)
            {
                return NotFound();
            }

            var dto = Mapper.Map<EmpresasDTO>(empresa);
            //Esto esta pero no puede mapear no se porque devuelvo del modelo directamente 
            //quisiera devolver EmpresasDTO mejor


            return Ok(dto);


        }



        // PUT: api/Empresas/5
        //[HttpPut("{id}")]
        [HttpPost("{id}")]
        public async Task<IActionResult> PutEmpresas(int id, Empresas empresas)
        {
            if (id != empresas.IdEmpresa)
            {
                return BadRequest();
            }

            _context.Entry(empresas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresasExists(id))
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


        
       


        // POST: api/Empresas
        [HttpPost]
        public async Task<ActionResult<Empresas>> PostEmpresas(Empresas empresas)
        {
            _context.Empresas.Add(empresas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresas", new { id = empresas.IdEmpresa }, empresas);
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empresas>> DeleteEmpresas(int id)
        {
            var empresas = await _context.Empresas.FindAsync(id);
            if (empresas == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresas);
            await _context.SaveChangesAsync();

            return empresas;
        }

        private bool EmpresasExists(int id)
        {
            return _context.Empresas.Any(e => e.IdEmpresa == id);
        }
    }
}

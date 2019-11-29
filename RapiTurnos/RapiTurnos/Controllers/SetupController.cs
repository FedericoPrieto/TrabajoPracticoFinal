using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RapiTurnos.Models;

namespace RapiTurnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetupController : ControllerBase
    {
        private readonly TurnosWebContext _context;

        public SetupController(TurnosWebContext context)
        {
            _context = context;
        }

        // POST: api/Startup
        [HttpPost]
        public async Task<ActionResult> Startup()
        {
            //Localidad
            var localidad = new Localidades()
            {
                Descripcion = "Localidad Startup"
            };
            _context.Localidades.Add(localidad);

            //Rubros
            var rubro = _context.Rubros.FirstOrDefault(x => x.Descripcion == "Rubro Startup");
            
            if (rubro == null)
            {
                short rubroid = 0;

                if (_context.Rubros.Count() != 0)
                {
                    rubroid = _context.Rubros.Max(x => x.RubroId);
                }
                
                rubro = new Rubros()
                {
                    RubroId = Convert.ToInt16(rubroid + 1),
                    Descripcion = "Rubro Startup"
                };

            }

            
            _context.Rubros.Add(rubro);
            await _context.SaveChangesAsync();


            var empresa = new Empresas()
            {
                Alias = "Empresa Alias Startup",
                Descripcion = "Descripcion Startup",
                EstadoActual = 1,
                IdLocalidad = localidad.IdLocalidad,
                RubroId = rubro.RubroId,
                Rubro = rubro,
                Email = "Email Startup",
                Password = "Password Startup",
                Nombre = "Startup S.A"
            };

            _context.Empresas.Add(empresa);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (System.Exception e)
            {
                return BadRequest("No se pudo generar el Startup");
                
            }

            return Ok();
        }

        // DELETE: api/Reset
        [HttpDelete]
        public async Task<ActionResult> Reset()
        {
            //var empresasServicios = await _context.EmpresasServicios.FindAsync(id);
            //if (empresasServicios == null)
            //{
            //    return NotFound();
            //}

            //_context.EmpresasServicios.Remove(empresasServicios);
            //await _context.SaveChangesAsync();

            return await Task.Run(() => Ok());
        }

        
    }
}

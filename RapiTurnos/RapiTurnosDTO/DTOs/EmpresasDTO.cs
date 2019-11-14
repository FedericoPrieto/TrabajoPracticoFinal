using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiTurnosDTO.DTOs
{
    public class EmpresasDTO
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }
        public string Descripcion { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public short EstadoActual { get; set; }
        public short RubroId { get; set; }
        public byte[] Logo { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public short IdLocalidad { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual LocalidadesDTO IdLocalidadNavigation { get; set; }
        public virtual RubrosDTO Rubro { get; set; }
        public virtual List<EmpresasServiciosDTO> EmpresasServicios { get; set; }
        public virtual List<PersonasDTO> Personas { get; set; }
        //public virtual List<RubrosDTO> Rubros { get; set; } /*OJO ES SIMPLEMENTE PARA EL ALTA PARA CARGAR COMBO*/

    }
}

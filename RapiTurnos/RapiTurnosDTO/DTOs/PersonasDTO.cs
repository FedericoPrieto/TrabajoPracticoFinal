using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiTurnosDTO.DTOs
{
    public class PersonasDTO
    {
        public int IdPersona { get; set; }
        public int IdEmpresa { get; set; }
        public short IdDuracionTurno { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Lugar { get; set; }
        public short EstadoActual { get; set; }
        public string Celular { get; set; }

        public virtual DuracionTurnosDTO IdDuracionTurnoNavigation { get; set; }
        public virtual EmpresasDTO IdEmpresaNavigation { get; set; }
        public virtual List<PersonasServiciosDTO> PersonasServicios { get; set; }
    }
}

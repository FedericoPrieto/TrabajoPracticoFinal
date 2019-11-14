using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiTurnosDTO.DTOs
{
    public class DuracionTurnosDTO
    {
        public short IdDuracionTurno { get; set; }
        public string Descripcion { get; set; }
        public short Minutos { get; set; }

        public virtual List<EmpresasServiciosDTO> EmpresasServicios { get; set; }
        public virtual List<PersonasDTO> Personas { get; set; }
    }
}

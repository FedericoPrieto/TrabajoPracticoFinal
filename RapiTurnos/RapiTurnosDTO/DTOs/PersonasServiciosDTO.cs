using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiTurnosDTO.DTOs
{
    public class PersonasServiciosDTO

    {
        public int IdPersonaServicio { get; set; }
        public int IdPersona { get; set; }
        public short? IdServicio { get; set; }
        public decimal? PrecioSugerido { get; set; }

        public virtual PersonasDTO IdPersonaNavigation { get; set; }
        public virtual EmpresasServiciosDTO IdServicioNavigation { get; set; }

    }
}

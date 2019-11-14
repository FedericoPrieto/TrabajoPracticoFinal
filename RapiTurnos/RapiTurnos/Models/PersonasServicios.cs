using System;
using System.Collections.Generic;

namespace RapiTurnos.Models
{
    public partial class PersonasServicios
    {
        public int IdPersonaServicio { get; set; }
        public int IdPersona { get; set; }
        public short? IdServicio { get; set; }
        public decimal? PrecioSugerido { get; set; }

        public virtual Personas IdPersonaNavigation { get; set; }
        public virtual EmpresasServicios IdServicioNavigation { get; set; }
    }
}

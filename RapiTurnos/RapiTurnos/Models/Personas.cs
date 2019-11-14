using System;
using System.Collections.Generic;

namespace RapiTurnos.Models
{
    public partial class Personas
    {
        public Personas()
        {
            PersonasServicios = new HashSet<PersonasServicios>();
        }

        public int IdPersona { get; set; }
        public int IdEmpresa { get; set; }
        public short IdDuracionTurno { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Lugar { get; set; }
        public short EstadoActual { get; set; }
        public string Celular { get; set; }

        public virtual DuracionTurnos IdDuracionTurnoNavigation { get; set; }
        public virtual Empresas IdEmpresaNavigation { get; set; }
        public virtual ICollection<PersonasServicios> PersonasServicios { get; set; }
    }
}

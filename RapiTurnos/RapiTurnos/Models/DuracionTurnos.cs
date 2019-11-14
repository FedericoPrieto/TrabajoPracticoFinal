using System;
using System.Collections.Generic;

namespace RapiTurnos.Models
{
    public partial class DuracionTurnos
    {
        public DuracionTurnos()
        {
            EmpresasServicios = new HashSet<EmpresasServicios>();
            Personas = new HashSet<Personas>();
        }

        public short IdDuracionTurno { get; set; }
        public string Descripcion { get; set; }
        public short Minutos { get; set; }

        public virtual ICollection<EmpresasServicios> EmpresasServicios { get; set; }
        public virtual ICollection<Personas> Personas { get; set; }
    }
}

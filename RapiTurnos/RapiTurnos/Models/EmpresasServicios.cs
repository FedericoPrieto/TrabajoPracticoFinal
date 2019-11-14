using System;
using System.Collections.Generic;

namespace RapiTurnos.Models
{
    public partial class EmpresasServicios
    {
        public EmpresasServicios()
        {
            PersonasServicios = new HashSet<PersonasServicios>();
        }

        public short IdServicio { get; set; }
        public int IdEmpresa { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioSugerido { get; set; }
        public short IdDuracionTurno { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual DuracionTurnos IdDuracionTurnoNavigation { get; set; }
        public virtual Empresas IdEmpresaNavigation { get; set; }
        public virtual ICollection<PersonasServicios> PersonasServicios { get; set; }
    }
}

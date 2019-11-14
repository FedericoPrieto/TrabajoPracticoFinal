using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiTurnosDTO.DTOs
{
    public class EmpresasServiciosDTO
    {
        public short IdServicio { get; set; }
        public int IdEmpresa { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioSugerido { get; set; }
        public short IdDuracionTurno { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual DuracionTurnosDTO IdDuracionTurnoNavigation { get; set; }
        public virtual EmpresasDTO IdEmpresaNavigation { get; set; }
        public virtual List<PersonasServiciosDTO> PersonasServicios { get; set; }
    }
}

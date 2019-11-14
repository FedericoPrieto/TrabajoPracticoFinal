using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiTurnosDTO.DTOs
{
    public class LocalidadesDTO
    {
        public short IdLocalidad { get; set; }
        public string Descripcion { get; set; }

        public virtual List<EmpresasDTO> Empresas { get; set; }
    }
}

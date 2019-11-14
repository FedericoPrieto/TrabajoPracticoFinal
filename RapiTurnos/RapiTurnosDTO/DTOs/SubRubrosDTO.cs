using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RapiTurnosDTO.DTOs
{
    public class SubRubrosDTO
    {
        public int SubRubroId { get; set; }
        public short RubroId { get; set; }
        public string Descripcion { get; set; }
        public virtual RubrosDTO Rubro { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace RapiTurnos.Models
{
    public partial class SubRubros
    {
        public int SubRubroId { get; set; }
        public short RubroId { get; set; }
        public string Descripcion { get; set; }

        public virtual Rubros Rubro { get; set; }
    }
}

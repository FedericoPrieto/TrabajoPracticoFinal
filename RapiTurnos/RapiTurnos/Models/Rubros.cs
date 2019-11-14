using System;
using System.Collections.Generic;

namespace RapiTurnos.Models
{
    public partial class Rubros
    {
        public Rubros()
        {
            Empresas = new HashSet<Empresas>();
            SubRubros = new HashSet<SubRubros>();
        }

        public short RubroId { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Empresas> Empresas { get; set; }
        public virtual ICollection<SubRubros> SubRubros { get; set; }
    }
}

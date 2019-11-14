using System;
using System.Collections.Generic;

namespace RapiTurnos.Models
{
    public partial class Localidades
    {
        public Localidades()
        {
            Empresas = new HashSet<Empresas>();
        }

        public short IdLocalidad { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Empresas> Empresas { get; set; }
    }
}

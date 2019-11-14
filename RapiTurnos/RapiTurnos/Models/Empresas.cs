using System;
using System.Collections.Generic;

namespace RapiTurnos.Models
{
    public partial class Empresas
    {
        public Empresas()
        {
            EmpresasServicios = new HashSet<EmpresasServicios>();
            Personas = new HashSet<Personas>();
        }

        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Alias { get; set; }
        public string Descripcion { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public short EstadoActual { get; set; }
        public short RubroId { get; set; }
        public byte[] Logo { get; set; }
        public string Direccion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public short IdLocalidad { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual Localidades IdLocalidadNavigation { get; set; }
        public virtual Rubros Rubro { get; set; }
        public virtual ICollection<EmpresasServicios> EmpresasServicios { get; set; }
        public virtual ICollection<Personas> Personas { get; set; }
    }
}

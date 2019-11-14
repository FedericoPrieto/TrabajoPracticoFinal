using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RapiTurnosDTO.DTOs
{
    public class UsuariosDTO
    {
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
        public string Rol { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace abcindustrialtx.Entities.DTO
{
    public class UsuarioUpdateDto
    {
        [Required]
        public int IdUsuario { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
    }
}

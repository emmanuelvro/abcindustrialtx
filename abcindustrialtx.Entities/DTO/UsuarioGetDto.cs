using System;

namespace abcindustrialtx.Entities.DTO
{
    public class UsuarioGetDto
    {
        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public short? UsrActivo { get; set; }
        public DateTimeOffset? FechaAlta { get; set; }
    }
}

using System;

namespace abcindustrialtx.Entities.DTO
{
    public class UsuarioDto : UsuarioLoginDTO
    {
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public byte UsrActivo { get; set; }
        public string IdRol { get; set; }
        public DateTime FechaAlta { get; set; }
        public string PasswordSalt { get; set; }
    }
}

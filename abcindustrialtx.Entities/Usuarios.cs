using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class Usuarios
    {
        public Usuarios()
        {
            UsuariosRoles = new HashSet<UsuariosRoles>();
        }

        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
        public short? UsrActivo { get; set; }
        public DateTimeOffset? FechaAlta { get; set; }

        public virtual ICollection<UsuariosRoles> UsuariosRoles { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatUsuario
    {
        public CatUsuario()
        {
            UsuarioRoles = new HashSet<UsuarioRoles>();
        }

        public int IdUsuario { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Correo { get; set; }
        public int? Telefono { get; set; }
        public byte UsrActivo { get; set; }
        public string IdRol { get; set; }

        public virtual ICollection<UsuarioRoles> UsuarioRoles { get; set; }
    }
}

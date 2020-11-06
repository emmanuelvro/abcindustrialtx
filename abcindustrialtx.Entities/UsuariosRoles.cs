using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class UsuariosRoles
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }

        public virtual Roles IdRolNavigation { get; set; }
        public virtual Usuarios IdUsuarioNavigation { get; set; }
    }
}

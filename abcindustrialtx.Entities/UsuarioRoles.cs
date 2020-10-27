using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class UsuarioRoles
    {
        public int IdUsuario { get; set; }
        public int IdRol { get; set; }

        public virtual CatUsuario IdUsuarioNavigation { get; set; }
    }
}

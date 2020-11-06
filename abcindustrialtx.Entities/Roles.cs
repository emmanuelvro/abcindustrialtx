using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class Roles
    {
        public Roles()
        {
            UsuariosRoles = new HashSet<UsuariosRoles>();
        }

        public int IdRol { get; set; }
        public string NombreRol { get; set; }

        public virtual ICollection<UsuariosRoles> UsuariosRoles { get; set; }
    }
}

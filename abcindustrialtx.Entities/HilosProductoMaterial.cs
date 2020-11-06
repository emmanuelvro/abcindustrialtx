using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class HilosProductoMaterial
    {
        public int IdHilosproducto { get; set; }
        public int IdMaterial { get; set; }
        public bool Activo { get; set; }

        public virtual HilosProductos IdHilosproductoNavigation { get; set; }
        public virtual CatMaterial IdMaterialNavigation { get; set; }
    }
}

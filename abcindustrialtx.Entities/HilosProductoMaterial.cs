using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class HilosProductoMaterial
    {
        public int IdHilosproducto { get; set; }
        public int IdMaterial { get; set; }
        public short Activo { get; set; }
        public DateTime FechaMoficicacion { get; set; }

        public virtual HilosProductos IdHilosproductoNavigation { get; set; }
        public virtual CatMaterial IdMaterialNavigation { get; set; }
    }
}

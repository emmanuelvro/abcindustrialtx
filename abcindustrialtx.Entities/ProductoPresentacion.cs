using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class ProductoPresentacion
    {
        public int IdPresentacion { get; set; }
        public int IdHilosproducto { get; set; }
        public DateTime FechaModificacion { get; set; }
        public short Activo { get; set; }

        public virtual HilosProductos IdHilosproductoNavigation { get; set; }
        public virtual CatPresentacion IdPresentacionNavigation { get; set; }
    }
}

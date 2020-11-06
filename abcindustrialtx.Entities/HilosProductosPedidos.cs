using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class HilosProductosPedidos
    {
        public long IdDetallePedido { get; set; }
        public int IdHilosproducto { get; set; }

        public virtual HilosProductos IdHilosproductoNavigation { get; set; }
    }
}

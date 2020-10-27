using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class DetallePedido
    {
        public int IdPedido { get; set; }
        public int IdDetallePedido { get; set; }

        public virtual Pedidos IdPedidoNavigation { get; set; }
    }
}

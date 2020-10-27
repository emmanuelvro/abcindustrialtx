using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class Pedidos
    {
        public Pedidos()
        {
            DetallePedido = new HashSet<DetallePedido>();
        }

        public int IdPedido { get; set; }
        public int IdProducto { get; set; }

        public virtual TblProducto IdPedidoNavigation { get; set; }
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.Entities
{
    public class DetallePedido
    {
        public int IdDetalle { get; set; }
        public int IdPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public string Observaciones { get; set; }
        public short Activo { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual Pedidos Pedido { get; set; }
        public virtual Productos Producto { get; set; }
    }
}

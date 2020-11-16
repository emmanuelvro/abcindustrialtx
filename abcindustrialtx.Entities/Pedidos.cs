using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.Entities
{
    public class Pedidos
    {
        public Pedidos()
        {
            this.DetallePedido = new HashSet<DetallePedido>();
        }
        public int IdPedido { get; set; }
        public string NombreCliente { get; set; }
        public int IdStatus { get; set; }
        public int IdUsuario { get; set; }
        public short Activo { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
}

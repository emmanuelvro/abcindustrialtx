using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.Entities
{
    public class ProductoColor
    {
        public int IdProductoColor { get; set; }
        public int IdColor { get; set; }
        public int IdProducto { get; set; }
        public decimal Porcentaje { get; set; }
        public short Activo { get; set; }
        public DateTime FechaModificacion { get; set; }
        public virtual CatColores Color { get; set; }
        public virtual Productos Producto { get; set; }
    }
}

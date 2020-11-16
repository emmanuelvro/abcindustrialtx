using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.Entities
{
    public class Productos
    {
        public Productos()
        {
            this.ProductoColor = new HashSet<ProductoColor>();
            this.ProductoMaterial = new HashSet<ProductoMaterial>();
        }
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int IdCalibre { get; set; }
        public int IdPresentacion { get; set; }
        public int Stock { get; set; }
        public DateTime FechaModificacion { get; set; }
        public short Activo { get; set; }

        public virtual CatCalibre Calibre { get; set; }
        public virtual CatPresentacion Presentacion { get; set; }
        public virtual ICollection<ProductoColor> ProductoColor { get; set; }
        public virtual ICollection<ProductoMaterial> ProductoMaterial { get; set; }
        public virtual ICollection<DetallePedido> DetallePedido { get; set; }
    }
}

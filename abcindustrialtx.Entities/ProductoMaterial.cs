using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class ProductoMaterial
    {
        public int IdProductoMaterial { get; set; }
        public int IdProducto { get; set; }
        public int IdMaterial { get; set; }
        public DateTime FechaModificacion { get; set; }
        public short Activo { get; set; }

        public virtual CatMaterial Material { get; set; }
        public virtual Productos Producto { get; set; }

    }
}

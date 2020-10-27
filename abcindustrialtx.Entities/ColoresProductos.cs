using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class ColoresProductos
    {
        public int IdcoloresProductos { get; set; }
        public int IdProducto { get; set; }
        public int IdColor { get; set; }
        public byte Activo { get; set; }

        public virtual CatColores IdColorNavigation { get; set; }
        public virtual TblProducto IdProductoNavigation { get; set; }
    }
}

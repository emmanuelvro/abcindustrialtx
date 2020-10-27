using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class ProductosMateriales
    {
        public int IdproductosMateriales { get; set; }
        public int IdProducto { get; set; }
        public int IdMateriales { get; set; }
        public byte Activo { get; set; }

        public virtual CatHilosMateriales IdMaterialesNavigation { get; set; }
        public virtual TblProducto IdProductoNavigation { get; set; }
    }
}

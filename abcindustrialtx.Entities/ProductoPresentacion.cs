using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class ProductoPresentacion
    {
        public int IdproductoPresentacion { get; set; }
        public int IdPresentacion { get; set; }
        public int IdProducto { get; set; }
        public byte Activo { get; set; }

        public virtual TblProducto IdProductoNavigation { get; set; }
        public virtual CatPresentacion IdproductoPresentacionNavigation { get; set; }
    }
}

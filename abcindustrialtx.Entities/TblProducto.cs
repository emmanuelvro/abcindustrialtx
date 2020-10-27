using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class TblProducto
    {
        public TblProducto()
        {
            ColoresProductos = new HashSet<ColoresProductos>();
            ProductoPresentacion = new HashSet<ProductoPresentacion>();
            ProductosMateriales = new HashSet<ProductosMateriales>();
        }

        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int IdCalibre { get; set; }
        public byte? Activo { get; set; }
        public int IdColor { get; set; }

        public virtual CatCalibre IdCalibreNavigation { get; set; }
        public virtual Pedidos Pedidos { get; set; }
        public virtual ICollection<ColoresProductos> ColoresProductos { get; set; }
        public virtual ICollection<ProductoPresentacion> ProductoPresentacion { get; set; }
        public virtual ICollection<ProductosMateriales> ProductosMateriales { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatPresentacion
    {
        public CatPresentacion()
        {
            ProductoPresentacion = new HashSet<ProductoMaterial>();
        }

        public int IdPresentacion { get; set; }
        public string Presentacion { get; set; }
        public decimal Cantidad { get; set; }
        public DateTime FechaAlta { get; set; }
        public short Activo { get; set; }

        public virtual ICollection<ProductoMaterial> ProductoPresentacion { get; set; }
    }
}

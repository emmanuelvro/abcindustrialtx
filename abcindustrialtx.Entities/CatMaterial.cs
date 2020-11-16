using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatMaterial
    {
        public CatMaterial()
        {
            this.ProductoMaterial = new HashSet<ProductoMaterial>();
        }
        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; }
        public DateTime? FechaAlta { get; set; }
        public short? Activo { get; set; }

        public virtual ICollection<ProductoMaterial> ProductoMaterial { get; set; }

    }
}

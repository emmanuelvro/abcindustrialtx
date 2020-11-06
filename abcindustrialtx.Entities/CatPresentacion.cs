using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatPresentacion
    {
        public CatPresentacion()
        {
            ProductoPresentacion = new HashSet<ProductoPresentacion>();
        }

        public int IdPresentacion { get; set; }
        public string Presentacion { get; set; }
        public decimal Cantidad { get; set; }
        public bool Activo { get; set; }

        public virtual ICollection<ProductoPresentacion> ProductoPresentacion { get; set; }
    }
}

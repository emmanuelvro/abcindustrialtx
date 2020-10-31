using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatHilosMateriales
    {
        public CatHilosMateriales()
        {
            ProductosMateriales = new HashSet<ProductosMateriales>();
        }

        public int IdMateriales { get; set; }
        public string NombreMaterial { get; set; }
        public string ColorMaterial { get; set; }
        public DateTime FechaAlta { get; set; }
        public byte Activo { get; set; }

        public virtual HilosExistenciaMateriales HilosExistenciaMateriales { get; set; }
        public virtual ICollection<ProductosMateriales> ProductosMateriales { get; set; }
    }
}

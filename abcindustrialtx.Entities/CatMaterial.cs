using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatMaterial
    {
        public CatMaterial()
        {
            ExistenciaMateriales = new HashSet<ExistenciaMateriales>();
            HilosProductoMaterial = new HashSet<HilosProductoMaterial>();
        }

        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; }
        public string ColorMaterial { get; set; }
        public DateTime? FechaAlta { get; set; }
        public short? Activo { get; set; }

        public virtual ICollection<ExistenciaMateriales> ExistenciaMateriales { get; set; }
        public virtual ICollection<HilosProductoMaterial> HilosProductoMaterial { get; set; }
    }
}

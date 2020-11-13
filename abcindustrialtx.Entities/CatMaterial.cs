using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatMaterial
    {
        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; }
        public DateTime? FechaAlta { get; set; }
        public short? Activo { get; set; }

    }
}

using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatColores
    {
        public CatColores()
        {
            ColoresProductos = new HashSet<ColoresProductos>();
        }

        public int IdColor { get; set; }
        public string NombreDesc { get; set; }
        public string HexadecimalColor { get; set; }
        public DateTime FechaAlta { get; set; }
        public byte Activo { get; set; }

        public virtual HilosExistencias HilosExistencias { get; set; }
        public virtual ICollection<ColoresProductos> ColoresProductos { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatColores
    {
        public CatColores()
        {
            HilosProductos = new HashSet<HilosProductos>();
        }

        public int IdColor { get; set; }
        public string Nombre { get; set; }
        public string HexadecimalColor { get; set; }
        public short Activo { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual ICollection<HilosProductos> HilosProductos { get; set; }
    }
}

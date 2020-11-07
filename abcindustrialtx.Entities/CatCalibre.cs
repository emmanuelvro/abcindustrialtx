using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatCalibre
    {
        public CatCalibre()
        {
            HilosProductos = new HashSet<HilosProductos>();
        }

        public int IdCalibre { get; set; }
        public decimal Calibre { get; set; }
        public DateTime FechaModificacion { get; set; }
        public short Activo { get; set; }

        public virtual ICollection<HilosProductos> HilosProductos { get; set; }
    }
}

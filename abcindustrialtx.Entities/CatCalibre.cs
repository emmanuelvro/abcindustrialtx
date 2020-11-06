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
        public bool Activo { get; set; }

        public virtual ICollection<HilosProductos> HilosProductos { get; set; }
    }
}

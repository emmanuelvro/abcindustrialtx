using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class HilosExistencias
    {
        public HilosExistencias()
        {
            HilosProductos = new HashSet<HilosProductos>();
        }

        public int IdExistencia { get; set; }
        public int Cantidad { get; set; }
        public int CantidadBobinas { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IdColor { get; set; }

        public virtual ICollection<HilosProductos> HilosProductos { get; set; }
    }
}

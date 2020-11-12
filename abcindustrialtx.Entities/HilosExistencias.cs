using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class HilosExistencias
    {
        public HilosExistencias()
        {
        }

        public int IdExistencia { get; set; }
        public int IdHilosproducto { get; set; }
        public int Cantidad { get; set; }
        public int CantidadBobinas { get; set; }
        public DateTime FechaAlta { get; set; }

        public virtual HilosProductos IdHilosproductoNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class HilosExistencias
    {
        public int IdColor { get; set; }
        public int CantidadExistente { get; set; }
        public int CantidadBobinas { get; set; }

        public virtual CatColores IdColorNavigation { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatCalibre
    {

        public int IdCalibre { get; set; }
        public decimal Calibre { get; set; }
        public DateTime FechaModificacion { get; set; }
        public short Activo { get; set; }

    }
}

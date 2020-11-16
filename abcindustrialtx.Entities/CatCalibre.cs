using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace abcindustrialtx.Entities
{
    public partial class CatCalibre
    {
        public CatCalibre()
        {
            this.Productos = new HashSet<Productos>();
        }

        public int IdCalibre { get; set; }
        public decimal Calibre { get; set; }
        public DateTime FechaModificacion { get; set; }
        public short Activo { get; set; }
        public virtual ICollection<Productos> Productos { get; set; }
    }
}

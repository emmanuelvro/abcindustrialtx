using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.Entities.DTO
{
    public class CatColoresDTO
    {
        public int IdColor { get; set; }
        public string NombreDesc { get; set; }
        public string HexadecimalColor { get; set; }
        public DateTime FechaAlta { get; set; }
        public byte Activo { get; set; }

        //public virtual HilosExistencias HilosExistencias { get; set; }
        //public virtual List<ColoresProductos> ColoresProductos { get; set; }
    }
}

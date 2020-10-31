using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.Entities.DTO
{
    public class CatCalibreDTO
    {
        public int IdCalibre { get; set; }
        public float CalibreDesc { get; set; }
        public DateTime FechaAlta { get; set; }
        public byte? Activo { get; set; }
    }
}

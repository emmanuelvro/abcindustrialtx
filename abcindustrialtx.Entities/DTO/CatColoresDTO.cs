using System;

namespace abcindustrialtx.Entities.DTO
{
    public class CatColoresDTO
    {
        public int IdColor { get; set; }
        public string Nombre { get; set; }
        public string HexadecimalColor { get; set; }
        public DateTime FechaAlta { get; set; }
        public byte Activo { get; set; }

        //public virtual List<ColoresProductos> ColoresProductos { get; set; }
    }
}

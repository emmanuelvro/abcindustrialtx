using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.Entities
{
    public class Productos
    {
        public int IdProducto { get; set; }
        public string Descripcion { get; set; }
        public int IdCalibre { get; set; }
        public int IdPresentacion { get; set; }
        public int Stock { get; set; }
        public DateTime FechaModificacion { get; set; }
        public short Activo { get; set; }

        public virtual CatCalibre IdCalibreNavigation { get; set; }
        public virtual CatPresentacion IdPresentacionNavigation { get; set; }
    }
}

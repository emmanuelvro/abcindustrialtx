using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatCalibre
    {
        public CatCalibre()
        {
            TblProducto = new HashSet<TblProducto>();
        }

        public int IdCalibre { get; set; }
        public byte? Activo { get; set; }

        public virtual ICollection<TblProducto> TblProducto { get; set; }
    }
}

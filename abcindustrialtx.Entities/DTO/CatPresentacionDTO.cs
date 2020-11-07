using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.Entities.DTO
{
    public class CatPresentacionDTO
    {
        public int IdPresentacion { get; set; }
        public string Presentacion { get; set; }
        public decimal Cantidad { get; set; }
        public bool Activo { get; set; }

    }
}

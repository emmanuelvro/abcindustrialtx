using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.Entities.DTO
{
    public class CatPresentacionDTO
    {
        public int IdPresentacion { get; set; }
        public string PresentacionDesc { get; set; }
        public float? Cantidad { get; set; }
        public bool Activo { get; set; }
        public DateTime FechaAlta { get; set; }

    }
}

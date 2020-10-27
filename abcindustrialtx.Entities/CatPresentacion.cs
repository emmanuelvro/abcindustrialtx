using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class CatPresentacion
    {
        public int IdPresentacion { get; set; }
        public string PresentaciónDesc { get; set; }
        public float? Cantidad { get; set; }
        public byte Activo { get; set; }

        public virtual ProductoPresentacion ProductoPresentacion { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class ExistenciaMateriales
    {
        public int IdExistenciaMaterial { get; set; }
        public int? IdMaterial { get; set; }
        public bool FechaModificacion { get; set; }

        public virtual CatMaterial IdMaterialNavigation { get; set; }
    }
}

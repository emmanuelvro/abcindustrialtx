using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class HilosExistenciaMateriales
    {
        public int IdMateriales { get; set; }

        public virtual CatHilosMateriales IdMaterialesNavigation { get; set; }
    }
}

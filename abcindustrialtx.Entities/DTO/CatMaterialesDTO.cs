using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.Entities.DTO
{
    public class CatMaterialesDTO
    {
        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; }
        public string ColorMaterial { get; set; }
        public bool? Activo { get; set; }
    }
}

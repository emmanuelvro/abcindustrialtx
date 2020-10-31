using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.Entities.DTO
{
    public class CatMaterialesDTO
    {
        public int IdMateriales { get; set; }
        public string NombreMaterial { get; set; }
        public string ColorMaterial { get; set; }
        public DateTime FechaAlta { get; set; }
        public byte Activo { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace abcindustrialtx.Entities.DTO
{
    public class HilosProductosCreateDTO
    {
        [Required]
        public int IdColor { get; set; }

        [Required]
        public int? IdCalibre { get; set; }
        public decimal? PorcentajeColor { get; set; }
        public string Descripcion { get; set; }
        public int IdPresentacion { get; set; }
        public int IdMaterial { get; set; }
        public decimal Cantidad { get; set; }
    }
}

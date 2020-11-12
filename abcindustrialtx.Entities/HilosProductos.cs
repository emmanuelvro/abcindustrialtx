using System;
using System.Collections.Generic;

namespace abcindustrialtx.Entities
{
    public partial class HilosProductos
    {
        public HilosProductos()
        {
            HilosProductoMaterial = new HashSet<HilosProductoMaterial>();
            HilosProductosPedidos = new HashSet<HilosProductosPedidos>();
            ProductoPresentacion = new HashSet<ProductoPresentacion>();
            HilosExistencias = new HashSet<HilosExistencias>();
        }

        public int IdHilosproducto { get; set; }
        public int IdColor { get; set; }
        public int? IdCalibre { get; set; }
        public DateTime FechaModificacion { get; set; }
        public short Activo { get; set; }
        public decimal? PorcentajeColor { get; set; }
        public string Descripcion { get; set; }

        public virtual CatCalibre IdCalibreNavigation { get; set; }
        public virtual CatColores IdColorNavigation { get; set; }
        public virtual ICollection<HilosProductoMaterial> HilosProductoMaterial { get; set; }
        public virtual ICollection<HilosProductosPedidos> HilosProductosPedidos { get; set; }
        public virtual ICollection<ProductoPresentacion> ProductoPresentacion { get; set; }
        public virtual ICollection<HilosExistencias> HilosExistencias { get; set; }
    }
}

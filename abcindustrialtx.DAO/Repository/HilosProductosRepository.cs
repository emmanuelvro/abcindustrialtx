using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace abcindustrialtx.DAO.Repository
{
    public class HilosProductosRepository : Global<HilosProductos>, IHilosProductosDAO
    {
        private readonly AbcIndustrialDbContext _context;

        public HilosProductosRepository(AbcIndustrialDbContext context)
            : base(context)
        {
            _context = context;
        }

        public async Task InsertarProducto(HilosProductos hilosProductos, CatPresentacion catPresentacion, CatMaterial catMaterial, HilosProductosPedidos hilosProductosPedidos)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                hilosProductos.FechaModificacion = DateTime.Now;
                hilosProductos.Activo = 1;
                HilosProductos producto = this.Insert(hilosProductos);

                if (producto != null)
                {
                    _context.ProductoPresentacion.Add(new ProductoPresentacion
                    {
                        IdHilosproducto = producto.IdHilosproducto,
                        IdPresentacion = catPresentacion.IdPresentacion,
                        FechaModificacion = DateTime.Now,
                        Activo = 1,

                    });
                    _context.SaveChanges();

                    _context.HilosProductoMaterial.Add(new HilosProductoMaterial
                    {
                        IdHilosproducto = producto.IdHilosproducto,
                        IdMaterial = catMaterial.IdMaterial,
                        FechaMoficicacion = DateTime.Now,
                        Activo = 1
                    });
                    _context.SaveChanges();
                    //_context.HilosProductosPedidos.Add(new HilosProductosPedidos
                    //{
                    //    IdHilosproducto = producto.IdHilosproducto,
                    //    FechaPedido = DateTime.Now,
                    //    Cantidad = hilosProductosPedidos.Cantidad
                    //});

                    await transaction.CommitAsync();
                }


            }
            catch (Exception ex)
            {
            }

        }
    }
}

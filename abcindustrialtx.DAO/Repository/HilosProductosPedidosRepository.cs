using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Repository
{
    public class HilosProductosPedidosRepository : Global<HilosProductosPedidos>, IHilosProductosPedidosDAO
    {
        private readonly AbcIndustrialDbContext _context;

        public HilosProductosPedidosRepository(AbcIndustrialDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

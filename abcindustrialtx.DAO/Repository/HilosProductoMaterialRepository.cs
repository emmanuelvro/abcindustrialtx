using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Repository
{
    public class HilosProductoMaterialRepository : Global<HilosProductoMaterial>, IHilosProductoMaterialDAO
    {
        private readonly AbcIndustrialDbContext _context;

        public HilosProductoMaterialRepository(AbcIndustrialDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Repository
{
    public class ProductoPresentacionRepository : Global<ProductoPresentacion>, IProductoPresentacionDAO
    {
        private readonly AbcIndustrialDbContext _context;

        public ProductoPresentacionRepository(AbcIndustrialDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

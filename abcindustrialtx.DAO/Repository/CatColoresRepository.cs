using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Repository
{
    public class CatColoresRepository : Global<CatColores>, ICatColoresDAO
    {
        private readonly AbcIndustrialDbContext _context;

        public CatColoresRepository(AbcIndustrialDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

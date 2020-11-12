using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Repository
{
    public class CatCalibreRepository : Global<CatCalibre>, ICatCalibreDAO
    {
        private readonly AbcIndustrialDbContext _context;

        public CatCalibreRepository(AbcIndustrialDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

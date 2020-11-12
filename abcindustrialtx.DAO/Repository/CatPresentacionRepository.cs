using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Repository
{
    public class CatPresentacionRepository: Global<CatPresentacion>, ICatPresentacionDAO
    {
        private readonly AbcIndustrialDbContext _context;
        public CatPresentacionRepository(AbcIndustrialDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

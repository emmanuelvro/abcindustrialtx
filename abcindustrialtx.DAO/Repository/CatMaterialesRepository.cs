using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Repository
{
    public class CatMaterialesRepository : Global<CatMaterial>, ICatMaterialesDAO
    {
        private readonly AbcIndustrialDbContext _context;
        public CatMaterialesRepository(AbcIndustrialDbContext context): base (context)
        {
            _context = context;
        }
    }
}

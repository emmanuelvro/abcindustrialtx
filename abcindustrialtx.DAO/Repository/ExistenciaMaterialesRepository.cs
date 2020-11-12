using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Repository
{
    public class ExistenciaMaterialesRepository : Global<ExistenciaMateriales>, IExistenciaMaterialesDAO
    {
        private readonly AbcIndustrialDbContext _context;

        public ExistenciaMaterialesRepository(AbcIndustrialDbContext context)
            : base(context)
        {
            _context = context;
        }
    }
}

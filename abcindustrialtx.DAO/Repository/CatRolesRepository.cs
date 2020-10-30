using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Repository
{
    public class CatRolesRepository : Global<Roles>, IRolesDAO
    {
        private readonly AbcIndustrialDbContext _context = null;
        public CatRolesRepository(AbcIndustrialDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
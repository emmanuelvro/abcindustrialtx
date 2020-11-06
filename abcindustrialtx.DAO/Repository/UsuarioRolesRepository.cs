using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Repository
{
    public class UsuariosRolesRepository : Global<UsuariosRoles>, IUsuariosRolesDAO
    {
        private readonly AbcIndustrialDbContext _context = null;
        public UsuariosRolesRepository(AbcIndustrialDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Repository
{
    public class UsuarioRolesRepository : Global<UsuarioRoles>, IUsuarioRolesDAO
    {
        private readonly AbcIndustrialDbContext _context = null;
        public UsuarioRolesRepository(AbcIndustrialDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

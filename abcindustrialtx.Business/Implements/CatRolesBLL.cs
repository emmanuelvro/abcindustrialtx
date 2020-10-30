using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Implements
{
    public class CatRolesBLL : ICatRolesBLL
    {
        private readonly IRolesDAO _rolesDAO = null;

        public CatRolesBLL(IRolesDAO rolesDAO)
        {
            _rolesDAO = rolesDAO;
        }
        public IQueryable<Roles> GetRoles()
        {
            return _rolesDAO.Get();
        }
    }
}


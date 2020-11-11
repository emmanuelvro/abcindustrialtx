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

        public void Delete(Roles entidad)
        {
            _rolesDAO.Delete(entidad);
        }

        public Roles GetRolById(int id)
        {
            return _rolesDAO.GetById(id);
        }

        public Roles Insert(Roles entidad)
        {
            return _rolesDAO.Insert(entidad);
        }

        public void Update(Roles entidad, int id)
        {
            _rolesDAO.Update(entidad, id);
        }
    }
}


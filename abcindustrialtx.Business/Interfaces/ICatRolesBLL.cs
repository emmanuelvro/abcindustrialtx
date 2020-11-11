using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatRolesBLL
    {
        IQueryable<Roles> GetRoles();
        Roles Insert(Roles entidad);
        Roles GetRolById(int id);
        void Delete(Roles entidad);
        void Update(Roles entidad, int id);
    }
}
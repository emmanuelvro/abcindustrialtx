using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatRolesBLL
    {
        IQueryable<Roles> GetRoles();
    }
}
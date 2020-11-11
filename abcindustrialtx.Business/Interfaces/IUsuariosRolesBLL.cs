using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IUsuariosRolesBLL
    {
        IQueryable<UsuariosRoles> GetUsuariosRoles();
        UsuariosRoles Insert(UsuariosRoles entidad);
        UsuariosRoles GetUsuariosRolesById(int id);
        void Delete(UsuariosRoles entidad);
        void Update(UsuariosRoles entidad, int id);
    }
}

using abcindustrialtx.Entities;
using System.Collections.Generic;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatUsuarioBLL
    {
        Usuarios Insert(Usuarios entidad);
        IQueryable<Usuarios> GetUsers();
        Usuarios GetUserById(int id);
        Usuarios Login(Usuarios entidad);
        void Delete(Usuarios entidad);
        void Update(Usuarios entidad, int id);
        UsuariosRoles AddRolToUser(Usuarios user, Roles roles);
        IList<string> GetRolesByUser(Usuarios currentUser);
    }
}

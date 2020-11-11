using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Implements
{
    public class UsuariosRolesBLL : IUsuariosRolesBLL
    {
        private readonly IUsuarioRolesDAO _usuarioRolesDAO = null;

        public UsuariosRolesBLL(IUsuarioRolesDAO usuarioRolesDAO)
        {
            _usuarioRolesDAO = usuarioRolesDAO;
        }

        public void Delete(UsuariosRoles entidad)
        {
            _usuarioRolesDAO.Delete(entidad);
        }

        public IQueryable<UsuariosRoles> GetUsuariosRoles()
        {
            return _usuarioRolesDAO.Get();
        }

        public UsuariosRoles GetUsuariosRolesById(int id)
        {
            return _usuarioRolesDAO.GetById(id);
        }

        public UsuariosRoles Insert(UsuariosRoles entidad)
        {
            return _usuarioRolesDAO.Insert(entidad);
        }

        public void Update(UsuariosRoles entidad, int id)
        {
            _usuarioRolesDAO.Update(entidad, id);
        }
    }
}

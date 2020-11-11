using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using abcindustrialtx.Utilities.Implements;
using System.Linq;
using System.Threading.Tasks;

namespace abcindustrialtx.Business.Implements
{
    public class CatUsuarioBLL : ICatUsuarioBLL
    {
        private readonly ICatUsuarioDAO _catUsuarioDAO = null;
        private readonly IUsuariosRolesBLL _usuariosRolesBLL = null;

        public CatUsuarioBLL(ICatUsuarioDAO catUsuarioDAO, IUsuariosRolesBLL usuariosRolesBLL)
        {
            _catUsuarioDAO = catUsuarioDAO;
            _usuariosRolesBLL = usuariosRolesBLL;
        }

        public UsuariosRoles AddRolToUser(Usuarios user, Roles roles)
        {
            return _usuariosRolesBLL.Insert(new UsuariosRoles { IdUsuario = user.IdUsuario, IdRol = roles.IdRol });
        }

        public void Delete(Usuarios entidad)
        {
            _catUsuarioDAO.Delete(entidad);
        }

        public Usuarios GetUserById(int id)
        {
            return _catUsuarioDAO.GetById(id);
        }

        public IQueryable<Usuarios> GetUsers()
        {
            return _catUsuarioDAO.Get();
        }

        public Usuarios Insert(Usuarios entidad)
        {
            string generarSalt = AuthenticationAbc.GenerarSalString();

            entidad.PasswordHash = AuthenticationAbc.GenerarHash(entidad.PasswordHash, generarSalt);
            entidad.PasswordSalt = generarSalt;
            entidad.FechaAlta = System.DateTimeOffset.Now;
            entidad.UsrActivo = 1;

            return _catUsuarioDAO.Insert(entidad);
        }

        public Usuarios Login(Usuarios entidad)
        {
            return _catUsuarioDAO.Login(entidad.Username, entidad.PasswordHash);
        }

        public void Update(Usuarios entidad, int id)
        {
            string generarSalt = AuthenticationAbc.GenerarSalString();

            entidad.PasswordHash = AuthenticationAbc.GenerarHash(entidad.PasswordHash, generarSalt);
            entidad.PasswordSalt = generarSalt;
            entidad.FechaAlta = System.DateTimeOffset.Now;
            entidad.UsrActivo = 1;

            _catUsuarioDAO.Update(entidad, id);
        }
    }
}

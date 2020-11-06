using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using abcindustrialtx.Utilities.Implements;
using System.Linq;

namespace abcindustrialtx.DAO.Repository
{
    public class UsuariosRepository : Global<Usuarios>, IUsuariosDAO
    {
        private readonly AbcIndustrialDbContext _context = null;
        public UsuariosRepository(AbcIndustrialDbContext context) : base(context)
        {
            _context = context;
        }

        public Usuarios Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                Usuarios usuario = _context.Usuarios.FirstOrDefault(p => p.Username == username.Trim() && p.UsrActivo == true);

                if (usuario != null)
                {
                    if (AuthenticationAbc.VerificarHashPassword(password, usuario.PasswordSalt, usuario.PasswordHash))
                    {
                        return usuario;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }
    }
}

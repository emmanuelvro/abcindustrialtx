using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using abcindustrialtx.Utilities.Implements;
using System.Linq;

namespace abcindustrialtx.DAO.Repository
{
    public class CatUsuarioRepository : Global<CatUsuario>, ICatUsuarioDAO
    {
        private readonly AbcIndustrialDbContext _context = null;
        public CatUsuarioRepository(AbcIndustrialDbContext context) : base(context)
        {
            _context = context;
        }

        public CatUsuario Login(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                CatUsuario usuario = _context.CatUsuario.FirstOrDefault(p => p.Username == username.Trim() && p.UsrActivo == 1);

                if (usuario != null)
                {
                    if (AuthenticationAbc.VerificarHashPassword(password, usuario.PasswordSalt, usuario.Password))
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

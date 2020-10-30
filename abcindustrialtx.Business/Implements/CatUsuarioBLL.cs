using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using abcindustrialtx.Utilities.Implements;
using System;
using System.Linq;

namespace abcindustrialtx.Business.Implements
{
    public class CatUsuarioBLL : ICatUsuarioBLL
    {
        private readonly ICatUsuarioDAO _catUsuarioDAO = null;

        public CatUsuarioBLL(ICatUsuarioDAO catUsuarioDAO)
        {
            _catUsuarioDAO = catUsuarioDAO;
        }

        public IQueryable<Entities.CatUsuario> GetUsers()
        {
            return _catUsuarioDAO.Get();
        }

        public CatUsuario Insert(CatUsuario entidad)
        {
            string generarSalt = AuthenticationAbc.GenerarSalString();

            entidad.Password = AuthenticationAbc.GenerarHash(entidad.Password, generarSalt);
            entidad.PasswordSalt = generarSalt;
            entidad.FechaAlta = DateTime.Now;
            entidad.UsrActivo = 1;
            entidad.IdRol = "1";

            return _catUsuarioDAO.Insert(entidad);
        }

        public CatUsuario Login(CatUsuario entidad)
        {
            return _catUsuarioDAO.Login(entidad.Username, entidad.Password);
        }


    }
}


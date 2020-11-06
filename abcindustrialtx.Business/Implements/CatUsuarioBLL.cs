using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using abcindustrialtx.Utilities.Implements;
using System;
using System.Linq;

namespace abcindustrialtx.Business.Implements
{
    public class UsuariosBLL : IUsuariosBLL
    {
        private readonly IUsuariosDAO _UsuariosDAO = null;

        public UsuariosBLL(IUsuariosDAO UsuariosDAO)
        {
            _UsuariosDAO = UsuariosDAO;
        }

        public IQueryable<Entities.Usuarios> GetUsers()
        {
            return _UsuariosDAO.Get();
        }

        public Usuarios Insert(Usuarios entidad)
        {
            string generarSalt = AuthenticationAbc.GenerarSalString();

            entidad.PasswordHash = AuthenticationAbc.GenerarHash(entidad.PasswordHash, generarSalt);
            entidad.PasswordSalt = generarSalt;
            entidad.FechaAlta = DateTime.Now;
            entidad.UsrActivo = true;

            return _UsuariosDAO.Insert(entidad);
        }

        public Usuarios Login(Usuarios entidad)
        {
            return _UsuariosDAO.Login(entidad.Username, entidad.PasswordHash);
        }


    }
}


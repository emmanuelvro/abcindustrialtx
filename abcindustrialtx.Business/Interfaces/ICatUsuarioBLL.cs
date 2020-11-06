using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IUsuariosBLL
    {
        Usuarios Insert(Usuarios entidad);
        IQueryable<Usuarios> GetUsers();
        Usuarios Login(Usuarios entidad);
    }
}

using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatUsuarioBLL
    {
        CatUsuario Insert(CatUsuario entidad);
        IQueryable<CatUsuario> GetUsers();
        CatUsuario Login(CatUsuario entidad);
    }
}

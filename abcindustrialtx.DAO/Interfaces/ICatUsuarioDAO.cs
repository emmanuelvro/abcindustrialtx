using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Interfaces
{
    public interface ICatUsuarioDAO: IGlobalDAO<CatUsuario>
    {
        CatUsuario Login(string username, string password);
    }
}

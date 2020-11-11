using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Interfaces
{
    public interface ICatUsuarioDAO: IGlobalDAO<Usuarios>
    {
        Usuarios Login(string username, string password);
    }
}

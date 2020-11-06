using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Interfaces
{
    public interface IUsuariosDAO: IGlobalDAO<Usuarios>
    {
        Usuarios Login(string username, string password);
    }
}

using abcindustrialtx.Entities;
using System.Threading.Tasks;

namespace abcindustrialtx.DAO.Interfaces
{
    public interface IHilosProductosDAO : IGlobalDAO<HilosProductos>
    {
        Task InsertarProducto(HilosProductos hilosProductos, CatPresentacion catPresentacion, CatMaterial catMaterial, HilosProductosPedidos hilosProductosPedidos);
    }
}

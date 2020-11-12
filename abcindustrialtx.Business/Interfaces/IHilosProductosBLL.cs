using abcindustrialtx.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IHilosProductosBLL
    {
        IQueryable<HilosProductos> GetHilosProductos();
        HilosProductos Insert(HilosProductos entidad);
        HilosProductos GetHilosProductosById(int id);
        void Delete(HilosProductos entidad);
        void Update(HilosProductos entidad, int id);
        Task InsertarProducto(HilosProductos hilosProductos, CatPresentacion catPresentacion, CatMaterial catMaterial, HilosProductosPedidos hilosProductosPedidos);
    }
}

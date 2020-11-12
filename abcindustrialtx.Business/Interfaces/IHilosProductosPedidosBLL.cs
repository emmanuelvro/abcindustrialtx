using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IHilosProductosPedidosBLL
    {
        HilosProductosPedidos Insert(HilosProductosPedidos entidad);
        IQueryable<HilosProductosPedidos> GetHilosProductosPedidos();
        HilosProductosPedidos GetHilosProductosPedidosById(int id);
        void Delete(HilosProductosPedidos entidad);
        void Update(HilosProductosPedidos entidad, int id);
    }
}

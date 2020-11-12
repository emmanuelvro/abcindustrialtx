using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Implements
{
    public class HilosProductosPedidosBLL : IHilosProductosPedidosBLL
    {
        private readonly IHilosProductosPedidosDAO _hilosProductosPedidosDAO;
        public HilosProductosPedidosBLL(IHilosProductosPedidosDAO hilosProductosPedidosDAO)
        {
            _hilosProductosPedidosDAO = hilosProductosPedidosDAO;
        }

        public void Delete(HilosProductosPedidos entidad)
        {
            _hilosProductosPedidosDAO.Delete(entidad);
        }

        public IQueryable<HilosProductosPedidos> GetHilosProductosPedidos()
        {
            return _hilosProductosPedidosDAO.Get();
        }

        public HilosProductosPedidos GetHilosProductosPedidosById(int id)
        {
            return _hilosProductosPedidosDAO.GetById(id);
        }

        public HilosProductosPedidos Insert(HilosProductosPedidos entidad)
        {
            return _hilosProductosPedidosDAO.Insert(entidad);
        }

        public void Update(HilosProductosPedidos entidad, int id)
        {
            _hilosProductosPedidosDAO.Update(entidad, id);
        }
    }
}

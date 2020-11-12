using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace abcindustrialtx.Business.Implements
{
    public class HilosProductosBLL : IHilosProductosBLL
    {
        private readonly IHilosProductosDAO _hilosProductosDAO;
        public HilosProductosBLL(IHilosProductosDAO hilosProductosDAO)
        {
            _hilosProductosDAO = hilosProductosDAO;
        }

        public void Delete(HilosProductos entidad)
        {
            _hilosProductosDAO.Delete(entidad);
        }

        public IQueryable<HilosProductos> GetHilosProductos()
        {
            return _hilosProductosDAO.Get();
        }

        public HilosProductos GetHilosProductosById(int id)
        {
            return _hilosProductosDAO.GetById(id);
        }

        public HilosProductos Insert(HilosProductos entidad)
        {
            return _hilosProductosDAO.Insert(entidad);
        }

        public async Task InsertarProducto(HilosProductos hilosProductos, CatPresentacion catPresentacion, CatMaterial catMaterial, HilosProductosPedidos hilosProductosPedidos)
        {
            await _hilosProductosDAO.InsertarProducto(hilosProductos, catPresentacion, catMaterial, hilosProductosPedidos);
        }

        public void Update(HilosProductos entidad, int id)
        {
            _hilosProductosDAO.Update(entidad, id);
        }
    }
}

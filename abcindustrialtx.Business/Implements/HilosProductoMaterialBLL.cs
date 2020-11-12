using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Implements
{
    public class HilosProductoMaterialBLL : IHilosProductoMaterialBLL
    {
        private readonly IHilosProductoMaterialDAO _hilosProductoMaterialDAO;
        public HilosProductoMaterialBLL(IHilosProductoMaterialDAO hilosProductoMaterialDAO)
        {
            _hilosProductoMaterialDAO = hilosProductoMaterialDAO;
        }
        public void Delete(HilosProductoMaterial entidad)
        {
            _hilosProductoMaterialDAO.Delete(entidad);
        }

        public IQueryable<HilosProductoMaterial> GetHilosProductoMaterial()
        {
            return _hilosProductoMaterialDAO.Get();
        }

        public HilosProductoMaterial GetHilosProductoMaterialById(int id)
        {
            return _hilosProductoMaterialDAO.GetById(id);
        }

        public HilosProductoMaterial Insert(HilosProductoMaterial entidad)
        {
            return _hilosProductoMaterialDAO.Insert(entidad);
        }

        public void Update(HilosProductoMaterial entidad, int id)
        {
            _hilosProductoMaterialDAO.Update(entidad, id);
        }
    }
}

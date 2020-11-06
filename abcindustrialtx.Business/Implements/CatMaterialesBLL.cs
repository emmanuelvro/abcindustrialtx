using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Implements
{
    public class CatMaterialesBLL: ICatMaterialesBLL
    {
        private readonly ICatMaterialesDAO _catMaterialesDao;
        public CatMaterialesBLL(ICatMaterialesDAO catColoresDao)
        {
            _catMaterialesDao = catColoresDao;
        }
        public void Delete(CatMaterial entidad)
        {
            _catMaterialesDao.Delete(entidad);
        }

        public CatMaterial GetMaterialById(int id)
        {
            return _catMaterialesDao.GetById(id);
        }

        public IQueryable<CatMaterial> GetMateriales()
        {
            return _catMaterialesDao.Get();
        }


        public void Update(CatMaterial entidad, int id)
        {
            _catMaterialesDao.Update(entidad, id);
        }

        public CatMaterial Insert(CatMaterial entidad)
        {
            return _catMaterialesDao.Insert(entidad);
        }
    }
}

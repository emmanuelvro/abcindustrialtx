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
        public CatHilosMateriales Insert(CatHilosMateriales entidad)
        {
            return _catMaterialesDao.Insert(entidad);
        }

        IQueryable<CatHilosMateriales> ICatMaterialesBLL.Get()
        {
            return _catMaterialesDao.Get();
        }
    }
}

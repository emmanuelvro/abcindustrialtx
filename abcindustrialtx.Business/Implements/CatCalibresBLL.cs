using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Implements
{
    public class CatCalibresBLL: ICatCalibresBLL
    {
        private readonly ICatCalibreDAO _catCalibresDao;

        public CatCalibresBLL(ICatCalibreDAO catCalibresDao)
        {
            _catCalibresDao = catCalibresDao;
        }
        public void Delete(CatCalibre entidad)
        {
            _catCalibresDao.Delete(entidad);
        }

        public CatCalibre GetCalibreById(int id)
        {
            return _catCalibresDao.GetById(id);
        }

        public IQueryable<Entities.CatCalibre> GetCalibres()
        {
            return _catCalibresDao.Get();
        }


        public void Update(CatCalibre entidad, int id)
        {
            _catCalibresDao.Update(entidad, id);
        }

        public CatCalibre Insert(CatCalibre entidad)
        {
            return _catCalibresDao.Insert(entidad);
        }

    }
}

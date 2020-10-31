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


        public IQueryable<CatCalibre> Get()
        {
            return _catCalibresDao.Get();
        }

        public CatCalibre Insert(CatCalibre entidad)
        {
            return _catCalibresDao.Insert(entidad);
        }

        //public async Task<List<CatColores>> GetAsync()
        //{
        //    try
        //    {
        //        return await _iProductosDAO.GetAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public CatColores GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<CatColores> GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

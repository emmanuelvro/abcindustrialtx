using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abcindustrialtx.Business.Implements
{
    public class CatCalibresBLL: Interfaces.ICatCalibresBLL
    {
        private readonly ICatCalibreDAO _catCalibresDao;

        public CatCalibresBLL(ICatCalibreDAO catCalibresDao)
        {
            _catCalibresDao = catCalibresDao;
        }


        public List<CatCalibre> Get()
        {
            return _catCalibresDao.Get().ToList();
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

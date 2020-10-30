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
    public class CatColoresBLL : Interfaces.ICatColoresBLL
    {
        private readonly ICatColoresDAO _catColoresDao;

        public CatColoresBLL(ICatColoresDAO catColoresDao)
        {
            _catColoresDao = catColoresDao;
        }


        public List<Entities.CatColores> Get()
        {
            return _catColoresDao.Get().ToList();
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

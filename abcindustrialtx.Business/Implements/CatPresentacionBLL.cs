using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Implements
{
    public class CatPresentacionBLL: ICatPresentacionBLL
    {
        private readonly ICatPresentacionDAO _catPresentacionDao;
        public CatPresentacionBLL(ICatPresentacionDAO catPresentacionDao)
        {
            _catPresentacionDao = catPresentacionDao;
        }
        //public List<CatPresentacion> Get()
        //{
        //    return _catPresentacionDao.Get().ToList();
        //}

        public CatPresentacion Insert(CatPresentacion entidad)
        {
            //entidad.NombreDesc = "";
            //entidad.FechaAlta = DateTime.Now;
            //entidad.Activo = 1;
            return _catPresentacionDao.Insert(entidad);
        }

        IQueryable<CatPresentacion> ICatPresentacionBLL.Get()
        {
            return _catPresentacionDao.Get();
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

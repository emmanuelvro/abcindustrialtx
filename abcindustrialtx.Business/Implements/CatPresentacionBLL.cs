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
        public void Delete(CatPresentacion entidad)
        {
            _catPresentacionDao.Delete(entidad);
        }

        public CatPresentacion GetPresentacionById(int id)
        {
            return _catPresentacionDao.GetById(id);
        }

        public IQueryable<CatPresentacion> GetPresentacion()
        {
            return _catPresentacionDao.Get();
        }


        public void Update(CatPresentacion entidad, int id)
        {
            _catPresentacionDao.Update(entidad, id);
        }

        public CatPresentacion Insert(CatPresentacion entidad)
        {
            return _catPresentacionDao.Insert(entidad);
        }
    }
}

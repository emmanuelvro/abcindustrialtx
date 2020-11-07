using abcindustrialtx.Business.Implements;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatPresentacionBLL
    {
        CatPresentacion Insert(CatPresentacion entidad);
        IQueryable<CatPresentacion> GetPresentacion();
        CatPresentacion GetPresentacionById(int id);
        void Delete(CatPresentacion entidad);
        void Update(CatPresentacion entidad, int id);
    }
}

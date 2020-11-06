using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using abcindustrialtx.Entities;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatCalibresBLL
    {
        CatCalibre Insert(CatCalibre entidad);
        IQueryable<CatCalibre> GetCalibres();
        CatCalibre GetCalibreById(int id);
        void Delete(CatCalibre entidad);
        void Update(CatCalibre entidad, int id);
    }
}

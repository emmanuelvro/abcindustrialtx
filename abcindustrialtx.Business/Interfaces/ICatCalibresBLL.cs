using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using abcindustrialtx.Entities;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatCalibresBLL
    {
        //CatColores GetById(int id);
        //Task<CatColores> GetByIdAsync(int id);
        IQueryable<CatCalibre> Get();
        CatCalibre Insert(CatCalibre entidad);
        //Task<List<CatColores>> GetAsync();
    }
}

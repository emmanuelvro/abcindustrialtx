using System;
using System.Collections.Generic;
using System.Text;
using abcindustrialtx.Entities;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatCalibresBLL
    {
        //CatColores GetById(int id);
        //Task<CatColores> GetByIdAsync(int id);
        List<CatCalibre> Get();
        //Task<List<CatColores>> GetAsync();
    }
}

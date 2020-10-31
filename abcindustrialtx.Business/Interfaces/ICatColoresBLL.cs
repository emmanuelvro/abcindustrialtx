using abcindustrialtx.Entities;
using System.Collections.Generic;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatColoresBLL
    {
        CatColores Insert(CatColores entidad);
        //CatColores GetById(int id);
        //Task<CatColores> GetByIdAsync(int id);
        IQueryable<CatColores> Get();
        //List<CatColores> Get();
        //Task<List<CatColores>> GetAsync();
    }
}


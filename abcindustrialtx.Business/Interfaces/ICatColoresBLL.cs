using abcindustrialtx.Entities;
using System.Collections.Generic;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatColoresBLL
    {
        CatColores Insert(CatColores entidad);
        IQueryable<CatColores> GetColors();
        CatColores GetColorById(int id);
        void Delete(CatColores entidad);
        void Update(CatColores entidad, int id);
    }
}


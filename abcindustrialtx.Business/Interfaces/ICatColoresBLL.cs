using abcindustrialtx.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatColoresBLL
    {
        //CatColores GetById(int id);
        //Task<CatColores> GetByIdAsync(int id);
        List<CatColores> Get();
        //Task<List<CatColores>> GetAsync();
    }
}


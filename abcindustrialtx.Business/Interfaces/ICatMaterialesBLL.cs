using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatMaterialesBLL
    {
        CatHilosMateriales Insert(CatHilosMateriales entidad);
        IQueryable<CatHilosMateriales> Get();
    }
}

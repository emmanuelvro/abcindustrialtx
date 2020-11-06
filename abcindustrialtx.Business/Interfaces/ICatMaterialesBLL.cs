using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface ICatMaterialesBLL
    {
        CatMaterial Insert(CatMaterial entidad);
        IQueryable<CatMaterial> GetMateriales();
        CatMaterial GetMaterialById(int id);
        void Delete(CatMaterial entidad);
        void Update(CatMaterial entidad, int id);
    }
}

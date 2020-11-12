using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IHilosProductoMaterialBLL
    {
        HilosProductoMaterial Insert(HilosProductoMaterial entidad);
        IQueryable<HilosProductoMaterial> GetHilosProductoMaterial();
        HilosProductoMaterial GetHilosProductoMaterialById(int id);
        void Delete(HilosProductoMaterial entidad);
        void Update(HilosProductoMaterial entidad, int id);
    }
}

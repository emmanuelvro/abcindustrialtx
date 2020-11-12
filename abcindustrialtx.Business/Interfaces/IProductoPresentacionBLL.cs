using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IProductoPresentacionBLL
    {
        ProductoPresentacion Insert(ProductoPresentacion entidad);
        IQueryable<ProductoPresentacion> GetProductosPresentacion();
        ProductoPresentacion GetProductosPresentacionById(int id);
        void Delete(ProductoPresentacion entidad);
        void Update(ProductoPresentacion entidad, int id);
    }
}

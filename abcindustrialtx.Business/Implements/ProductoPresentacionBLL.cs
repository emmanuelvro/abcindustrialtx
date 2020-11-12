using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Implements
{
    public class ProductoPresentacionBLL : IProductoPresentacionBLL
    {
        private readonly IProductoPresentacionDAO _productoPresentacionDAO;

        public ProductoPresentacionBLL(IProductoPresentacionDAO productoPresentacionDAO)
        {
            _productoPresentacionDAO = productoPresentacionDAO;
        }
        public void Delete(ProductoPresentacion entidad)
        {
            _productoPresentacionDAO.Delete(entidad);
        }

        public IQueryable<ProductoPresentacion> GetProductosPresentacion()
        {
            return _productoPresentacionDAO.Get();
        }

        public ProductoPresentacion GetProductosPresentacionById(int id)
        {
            return _productoPresentacionDAO.GetById(id);
        }

        public ProductoPresentacion Insert(ProductoPresentacion entidad)
        {
            return _productoPresentacionDAO.Insert(entidad);
        }

        public void Update(ProductoPresentacion entidad, int id)
        {
            _productoPresentacionDAO.Update(entidad, id);
        }
    }
}

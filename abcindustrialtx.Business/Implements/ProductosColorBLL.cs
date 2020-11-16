using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Implements
{
    public class ProductosColorBLL : IProductosColorBLL
    {
        private readonly IProductosColorDAO productosColorDao;
        public ProductosColorBLL(IProductosColorDAO _productosColorDao)
        {
            this.productosColorDao = _productosColorDao;
        }
        public void Delete(ProductoColor entidad)
        {
            this.productosColorDao.Delete(entidad);
        }

        public IQueryable<ProductoColor> GetProductosColor()
        {
            return this.productosColorDao.Get();
        }

        public ProductoColor GetProductosColorById(int id)
        {
            return this.productosColorDao.GetById(id);
        }

        public ProductoColor Insert(ProductoColor entidad)
        {
            return this.productosColorDao.Insert(entidad);
        }

        public void Update(ProductoColor entidad, int id)
        {
            this.productosColorDao.Update(entidad, id);
        }
    }
}

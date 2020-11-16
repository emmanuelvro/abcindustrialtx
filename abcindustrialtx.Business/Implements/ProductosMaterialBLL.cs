using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Implements
{
    public class ProductosMaterialBLL : IProductosMaterialBLL
    {
        private readonly IProductosMaterialDAO productosMaterialDao;
        public ProductosMaterialBLL(IProductosMaterialDAO _productosMaterialDao)
        {
            this.productosMaterialDao = _productosMaterialDao;
        }
        public void Delete(ProductoMaterial entidad)
        {
            this.productosMaterialDao.Delete(entidad);
        }

        public IQueryable<ProductoMaterial> GetProductosMaterial()
        {
            return this.productosMaterialDao.Get();
        }

        public ProductoMaterial GetProductosMaterialById(int id)
        {
            return this.productosMaterialDao.GetById(id);
        }

        public ProductoMaterial Insert(ProductoMaterial entidad)
        {
            return this.productosMaterialDao.Insert(entidad);
        }

        public void Update(ProductoMaterial entidad, int id)
        {
            this.productosMaterialDao.Update(entidad, id);
        }
    }
}

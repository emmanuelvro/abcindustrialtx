using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Implements
{
    public class ProductosBLL : IProductosBLL
    {
        private readonly IProductosDAO productosDao;
        public ProductosBLL(IProductosDAO _productosDao)
        {
            this.productosDao = _productosDao;
        }
        public void Delete(Productos entidad)
        {
            this.productosDao.Delete(entidad);
        }

        public IQueryable<Productos> GetProductos()
        {
            return this.productosDao.Get();
        }

        public Productos GetProductoseById(int id)
        {
            return this.productosDao.GetById(id);
        }

        public Productos Insert(Productos entidad)
        {
            return this.productosDao.Insert(entidad);
        }

        public void Update(Productos entidad, int id)
        {
            this.productosDao.Update(entidad, id);
        }
    }
}

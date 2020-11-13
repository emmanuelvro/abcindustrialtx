using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IProductosBLL
    {
        Productos Insert(Productos entidad);
        IQueryable<Productos> GetProductos();
        Productos GetProductoseById(int id);
        void Delete(Productos entidad);
        void Update(Productos entidad, int id);
    }
}

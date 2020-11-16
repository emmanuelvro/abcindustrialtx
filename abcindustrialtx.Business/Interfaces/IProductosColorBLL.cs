using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IProductosColorBLL
    {
        ProductoColor Insert(ProductoColor entidad);
        IQueryable<ProductoColor> GetProductosColor();
        ProductoColor GetProductosColorById(int id);
        void Delete(ProductoColor entidad);
        void Update(ProductoColor entidad, int id);
    }
}

using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IProductosMaterialBLL
    {
        ProductoMaterial Insert(ProductoMaterial entidad);
        IQueryable<ProductoMaterial> GetProductosMaterial();
        ProductoMaterial GetProductosMaterialById(int id);
        void Delete(ProductoMaterial entidad);
        void Update(ProductoMaterial entidad, int id);
    }
}

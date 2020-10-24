using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IProductosBsn
    {
        Producto GetById(int id);
        Task<Producto> GetByIdAsync(int id);
        List<Producto> Get();
        Task<List<Producto>> GetAsync();
    }
}

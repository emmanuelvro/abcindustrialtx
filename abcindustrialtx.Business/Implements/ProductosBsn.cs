using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace abcindustrialtx.Business.Implements
{
    public class ProductosBsn : IProductosBsn
    {
        private readonly IProductosDAO _iProductosDAO;

        public ProductosBsn(IProductosDAO productosDAO) => _iProductosDAO = productosDAO;

        public List<Producto> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<List<Producto>> GetAsync()
        {
            try
            {
                return await _iProductosDAO.GetAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Producto GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

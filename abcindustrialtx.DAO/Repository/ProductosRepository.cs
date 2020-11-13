using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.DAO.Repository
{
    public class ProductosRepository : Global<Productos>, IProductosDAO
    {
        private readonly AbcIndustrialDbContext _context;
        public ProductosRepository(AbcIndustrialDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

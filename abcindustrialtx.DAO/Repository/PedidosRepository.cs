using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.DAO.Repository
{
    public class PedidosRepository : Global<Pedidos>, IPedidosDAO
    {
        private readonly AbcIndustrialDbContext _context;
        public PedidosRepository(AbcIndustrialDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

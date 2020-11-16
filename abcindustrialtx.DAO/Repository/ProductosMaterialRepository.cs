﻿using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.DAO.Repository
{
    public class ProductosMaterialRepository : Global<ProductoMaterial>, IProductosMaterialDAO
    {
        private readonly AbcIndustrialDbContext _context;
        public ProductosMaterialRepository(AbcIndustrialDbContext context) : base(context)
        {
            _context = context;
        }
    }
}

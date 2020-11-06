﻿using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace abcindustrialtx.DAO.Repository
{
    public class CatMaterialesRepository : Global<CatMaterial>, ICatMaterialesDAO
    {
        private readonly AbcIndustrialDbContext _context;
        public CatMaterialesRepository(AbcIndustrialDbContext context): base (context)
        {
            _context = context;
        }
    }
}

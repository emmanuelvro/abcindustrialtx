﻿using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;

namespace abcindustrialtx.DAO.Repository
{
    public class HilosExistenciaRepository: Global<HilosExistencias>, IHilosExistenciaDAO
    {
        private readonly AbcIndustrialDbContext _context;
        public HilosExistenciaRepository(AbcIndustrialDbContext context) : base(context) 
        {
            _context = context;
        }
    }
}

using abcindustrialtx.DAO.Implements;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Text;

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

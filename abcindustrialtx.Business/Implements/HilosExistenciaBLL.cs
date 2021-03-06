﻿using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Implements
{
    public class HilosExistenciaBLL : IHilosExistenciaBLL
    {
        private readonly IHilosExistenciaDAO _hilosExistenciaDao;
        public HilosExistenciaBLL(IHilosExistenciaDAO hilosExistenciaDao)
        {
            _hilosExistenciaDao = hilosExistenciaDao;
        }

        public void Delete(HilosExistencias entidad)
        {
            _hilosExistenciaDao.Delete(entidad);
        }

        public IQueryable<HilosExistencias> Get()
        {
            return _hilosExistenciaDao.Get();
        }

        public IQueryable<HilosExistencias> GetHilosExistencias()
        {
            return _hilosExistenciaDao.Get();
        }

        public HilosExistencias GetHilosExistenciasById(int id)
        {
            return _hilosExistenciaDao.GetById(id);
        }

        public HilosExistencias Insert(HilosExistencias entidad)
        {
            return _hilosExistenciaDao.Insert(entidad);
        }

        public void Update(HilosExistencias entidad, int id)
        {
            _hilosExistenciaDao.Update(entidad, id);
        }
    }
}

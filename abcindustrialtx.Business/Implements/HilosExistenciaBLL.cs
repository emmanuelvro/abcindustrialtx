using abcindustrialtx.Business.Interfaces;
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

        public IQueryable<HilosExistencias> Get()
        {
            return _hilosExistenciaDao.Get();
        }
        public HilosExistencias Insert(HilosExistencias entidad)
        {
            return _hilosExistenciaDao.Insert(entidad);
        }


    }
}

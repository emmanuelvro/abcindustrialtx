
using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IHilosExistenciaBLL
    {
        HilosExistencias Insert(HilosExistencias entidad);
        IQueryable<HilosExistencias> Get();
        IQueryable<HilosExistencias> GetHilosExistencias();
        HilosExistencias GetHilosExistenciasById(int id);
        void Delete(HilosExistencias entidad);
        void Update(HilosExistencias entidad, int id);
    }
}

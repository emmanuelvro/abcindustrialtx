using abcindustrialtx.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace abcindustrialtx.Business.Interfaces
{
    public interface IHilosExistenciaBLL
    {
        HilosExistencias Insert(HilosExistencias entidad);
        IQueryable<HilosExistencias> Get();
    }
}

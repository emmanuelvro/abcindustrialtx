using abcindustrialtx.Business.Interfaces;
using abcindustrialtx.DAO.Interfaces;
using abcindustrialtx.Entities;
using System.Linq;

namespace abcindustrialtx.Business.Implements
{
    public class CatColoresBLL : ICatColoresBLL
    {
        private readonly ICatColoresDAO _catColoresDao;

        public CatColoresBLL(ICatColoresDAO catColoresDao)
        {
            _catColoresDao = catColoresDao;
        }
        public void Delete(CatColores entidad)
        {
            _catColoresDao.Delete(entidad);
        }

        public CatColores GetColorById(int id)
        {
            return _catColoresDao.GetById(id);
        }

        public IQueryable<Entities.CatColores> GetColors()
        {
            return _catColoresDao.Get();
        }


        public void Update(CatColores entidad, int id)
        {
            _catColoresDao.Update(entidad, id);
        }

        public CatColores Insert(CatColores entidad)
        {
            return _catColoresDao.Insert(entidad);
        }

    }
}

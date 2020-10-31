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


        //public List<CatColores> Get()
        //{
        //    return _catColoresDao.Get().ToList();
        //}

        public CatColores Insert(CatColores entidad)
        {
            //entidad.NombreDesc = "";
            //entidad.FechaAlta = DateTime.Now;
            //entidad.Activo = 1;
            return _catColoresDao.Insert(entidad);
        }

        IQueryable<CatColores> ICatColoresBLL.Get()
        {
            return _catColoresDao.Get();
        }

        //public async Task<List<CatColores>> GetAsync()
        //{
        //    try
        //    {
        //        return await _iProductosDAO.GetAsync();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public CatColores GetById(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<CatColores> GetByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

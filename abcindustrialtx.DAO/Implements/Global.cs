using abcindustrialtx.DAO.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace abcindustrialtx.DAO.Implements
{
    public class Global<T> : IGlobalDAO<T> where T : class
    {
        private readonly AbcIndustrialDbContext _context;

        public Global(AbcIndustrialDbContext context)
        {
            this._context = context;
        }

        public void Delete(T entidad)
        {
            _context.Set<T>().Remove(entidad);
            _context.SaveChanges();
        }

        public async Task<int> DeleteAsync(T entidad)
        {
            _context.Set<T>().Remove(entidad);
            return await _context.SaveChangesAsync();
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>();
        }

        public async Task<ICollection<T>> GetAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public T Insert(T entidad)
        {
            try
            {
                _context.Set<T>().Add(entidad);
                _context.SaveChanges();
            }
            catch (System.Exception e)
            {

                throw;
            }
            
            return entidad;
        }

        public async Task<T> InsertAsync(T entidad)
        {
            _context.Set<T>().Add(entidad);
            await _context.SaveChangesAsync();
            return entidad;
        }

        public T Update(T entidad, object key)
        {
            if (entidad == null)
                return null;
            T exist = _context.Set<T>().Find(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entidad);
                _context.SaveChanges();
            }
            return exist;
        }

        public async Task<T> UpdateAsync(T entidad, object key)
        {
            if (entidad == null)
                return null;
            T exist = await _context.Set<T>().FindAsync(key);
            if (exist != null)
            {
                _context.Entry(exist).CurrentValues.SetValues(entidad);
                await _context.SaveChangesAsync();
            }
            return exist;
        }
    }
}

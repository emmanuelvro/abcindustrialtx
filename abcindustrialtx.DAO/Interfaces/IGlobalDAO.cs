using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace abcindustrialtx.DAO.Interfaces
{
    public interface IGlobalDAO<T>
    {
        T Insert(T entidad);
        Task<T> InsertAsync(T entidad);
        T Update(T entidad, object key);
        Task<T> UpdateAsync(T entidad, object key);
        void Delete(T entidad);
        Task<int> DeleteAsync(T entidad);
        T GetById(object id);
        Task<T> GetByIdAsync(object id);
        IQueryable<T> Get();
        Task<ICollection<T>> GetAsync();
    }
}

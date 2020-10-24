using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace abcindustrialtx.DAO.Interfaces
{
    public interface IGlobal<T>
    {
        T Insert(T objeto);
        Task<T> InsertAsync(T objeto);
        T Update(T objeto);
        Task<T> UpdateAsync(T objeto);
        bool Delete(int id);
        Task<bool> DeleteAsync(int id);
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        List<T> Get();
        Task<List<T>> GetAsync();
    }
}

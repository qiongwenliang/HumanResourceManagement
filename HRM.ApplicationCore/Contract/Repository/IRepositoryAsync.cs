using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.ApplicationCore.Contract.Repository
{
    public interface IRepositoryAsync<T> where T : class
    {
        //These methods are like contracts that are used to update, delete, insert and get data
        //and each entity are using these methods to implement functions
        //but if each entity need to implement 5 times the methods, and the total No. of implementing
        //methods is (No. of entity) * 5, which will be a lot.
        //so we create a baserepository class in Infrastructure to better facilitate this.
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();

    }
}

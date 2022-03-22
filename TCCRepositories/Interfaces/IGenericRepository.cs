using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;

namespace TCCRepositories.Interfaces
{
    public interface IGenericRepository<T> where T: BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(long id);
        Task Insert(T entity);
        Task Delete(T entity);
        Task Update(T entity);
    }
}

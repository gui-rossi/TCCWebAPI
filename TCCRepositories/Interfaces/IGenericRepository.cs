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
        Task<IEnumerable<T>> SelectAllAsync(Func<IQueryable<T>, IQueryable<T>> query);
        Task<IEnumerable<T>> SelectAllAsync();
        Task<T> FindAsync(object key);
        void Insert(T entity);
        void Insert(IEnumerable<T> entities);
        void Delete(IEnumerable<T> entities);
        void Update(T entity);
        void Update(IEnumerable<T> entities);
        Task SaveChangesAsync();
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;
using TCCRepositories.Interfaces;

namespace TCCRepositories.DataRepository
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private DbSet<T> _entities;

        public GenericRepository()
        {

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<T> Get (long id)
        {
            return await _entities
                .AsNoTracking()
                .SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task Insert (T entity)
        {
            return await _entities.AddAsync(entity);
        }

        public async Task Delete(T entity)
        {

            return await _entities.Remove(entity);
        }

        public async Task Update(T entity)
        {

            return await _entities.AddAsync(entity);
        }
    }
}

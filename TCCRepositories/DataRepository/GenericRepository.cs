using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCCDomain.Entities;
using TCCRepositories.Interfaces;
using TCCRepositories.TCCContext;

namespace TCCRepositories.DataRepository
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity, new()
    {
        protected readonly DatabaseContext _db;
        protected readonly DbSet<T> _dbSet;

        public GenericRepository(DatabaseContext context)
        {
            if (context is null) throw new ArgumentNullException("Null Database context");

            _db = context;
            _dbSet = _db.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> SelectAllAsync()
        {
            return await _dbSet
                .AsNoTracking()
                .ToArrayAsync();
        }

        public virtual async Task<T> FindAsync(object key)
        {
            if (key is null) throw new ArgumentNullException(nameof(key) + "is null");

            var entity = await _dbSet.FindAsync(key);

            ValidateEntity(entity);

            return entity;
        }

        public void Insert(T entity)
        {
            ValidateEntity(entity);
            _dbSet.AddAsync(entity);
        }

        public void Insert(IEnumerable<T> entities)
        {
            ValidateEntities(entities);
            _dbSet.AddRangeAsync(entities);
        }

        public void Delete(IEnumerable<T> entities)
        {
            ValidateEntities(entities);
            _dbSet.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            ValidateEntity(entity);
            _dbSet.Update(entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            ValidateEntities(entities);
            _dbSet.UpdateRange(entities);
        }

        public Task SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }

        private void ValidateEntity(T entity)
        {
            if (entity is null) throw new ArgumentNullException("Null entity"); ;
        }

        private void ValidateEntities(IEnumerable<T> entities)
        {
            if (entities is null) throw new ArgumentNullException("Null array of entities"); ;
            if (!entities.Any()) throw new ArgumentNullException("Empty array of entities"); ;
            if (entities.Any(e => e is null)) throw new ArgumentNullException("Null entity inside array of entities"); ;
        }
    }
}

using CohesionApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CohesionApp.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity<T>
    {
        public readonly MyDbContext _dbContext;

        public BaseRepository(MyDbContext dbcontext) => _dbContext = dbcontext;

        public async Task<T> Create(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            var editedEntity = await _dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == entity.Id);
            editedEntity.CopyFrom(entity);
            await _dbContext.SaveChangesAsync();
            return editedEntity;
        }

        public async Task Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetById(Guid id)
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            IQueryable<T> query = _dbContext.Set<T>();
            return await query.ToListAsync();
        }
    }
}

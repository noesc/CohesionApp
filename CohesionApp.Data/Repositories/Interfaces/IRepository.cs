using CohesionApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CohesionApp.Data.Repositories
{
    public interface IRepository<T> where T : BaseEntity<T>
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Remove(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(Guid id);
    }
}

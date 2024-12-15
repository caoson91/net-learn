using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlazorRepository.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetQueryableAll();
        Task<T> GetAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entity);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entity);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> FindDataByPredicateAsync(Expression<Func<T, bool>> predicate);
        Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate);
    }
}

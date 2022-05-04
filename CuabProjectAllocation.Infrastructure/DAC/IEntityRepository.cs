using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Infrastructure.DAC
{
    public interface IEntityRepository<T> where T : class
    {
        Task<T> GetByAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions);
        Task<IReadOnlyList<T>> GetAllAsync();
        //Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>>[] includeExpression);
        Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec);
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}

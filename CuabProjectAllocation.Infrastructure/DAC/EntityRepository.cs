using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Infrastructure.DAC
{
    /// <summary>
    /// Generic Entity Repository
    /// Implements the <see cref="CuabProjectAllocation.Core.DAC.IEntityRepository{T}"/>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="CuabProjectAllocation.Core.DAC.IEntityRepository{T}"/>

    public class EntityRepository<T> : IEntityRepository<T> where T : class
    {
        private readonly CuabDbContext _dbContext;

        public EntityRepository(CuabDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
           

        public async Task<IReadOnlyList<T>> GetAllAsync(Expression<Func<T, bool>>[] includeExpression)
        {
            IQueryable<T> set = _dbContext.Set<T>();
            foreach (var expression in includeExpression)
            {
                set = set.Include(expression);
            }
            return await set.AsNoTracking().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetByAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeExpressions)
        {
            IQueryable<T> set = _dbContext.Set<T>();
            foreach(var includeExpression in includeExpressions)
            {
                set = set.Include(includeExpression);
            }
            T result = await set.FirstOrDefaultAsync();
            return result;
        }

        public int Insert(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            return _dbContext.SaveChanges();
        }

        public int Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}

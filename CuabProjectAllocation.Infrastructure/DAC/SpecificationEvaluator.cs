using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CuabProjectAllocation.Infrastructure.DAC
{
    /// <summary>
    /// Entity class Specification Pattern Evaluator
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public class SpecificationEvaluator<T> where T : class
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            if(specification.Criteria != null)
            {
                query = query.Where(specification.Criteria);
            }

            query = specification.Includes.Aggregate(query,
                                (current, include) => current.Include(include));

            if(specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);   
            }
            else if(specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);   
            }

            if(specification.GroupBy != null)
            {
                query = query.GroupBy(specification.GroupBy).SelectMany(x => x);
            }

            //Apply paging if enabled
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip)
                              .Take(specification.Take);
            }

            return query;
        }
    }
}

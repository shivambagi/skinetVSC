using Core.Entities;
using Core.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, //inputquery will be the IQueryable object like products
            ISpecifications<TEntity> spec)        
        {
            var query = inputQuery; // store that object in query

            if(spec.Criteria != null)
            {
                query = query.Where(spec.Criteria); // this will be the expression for criteria
            }

            //**** will generate include statements, aggregate them and pass them into query
            //**** it is an IQueryable which going to get passed to list
            query = spec.Includes.Aggregate(query,(current,include) => current.Include(include));

            return query;
        }
    }
}
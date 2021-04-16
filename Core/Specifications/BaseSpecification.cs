using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Specifications
{
    public class BaseSpecification<T> : ISpecification<T>
    {
        public BaseSpecification()
        {
        }

        public BaseSpecification(Expression<Func<T, bool>> critera)
        {
            Critera = critera;
        }

        public Expression<Func<T, bool>> Critera { get; }
        //list of include statements that we can pass to eg GetProductsAsync 
        //   ex:
        // return await _context.Products
        //         .Include(p => p.ProductType)
        //         .Include(p => p.ProductBrand)
        //         .ToListAsync();
        public List<Expression<Func<T, object>>> Includes { get; } =
             new List<Expression<Func<T, object>>>();

        protected void AddInclude(Expression<Func<T, object>> includeExpression)
        {
            this.Includes.Add(includeExpression);
        }
    }
}
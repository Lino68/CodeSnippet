using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Lino.CodeSnippet.Extensions
{
    public static class IQueryableExtension
    {
        public static IQueryable<T> Query<T>(this IQueryable<T> source, params Expression<Func<T, bool>>[] predicates)
        {
            if (source == null)
            {
                return null;
            }

            var result = source;
            foreach (var predicate in predicates)
            {
                result = source.Where<T>(predicate);
            }

            return result;
        }
    }
}

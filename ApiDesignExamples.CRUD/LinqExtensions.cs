using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDesignExamples.CRUD
{
    public static class LinqExtensions
    {
        public static async Task Each<T>(this IEnumerable<T> source, Func<T, Task> action)
        {
            foreach (var item in source)
            {
                await action(item).ConfigureAwait(false);
            }
        }
    }
}
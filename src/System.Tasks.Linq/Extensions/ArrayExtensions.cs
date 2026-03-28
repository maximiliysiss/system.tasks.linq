using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class ArrayExtensions
{
    public static async Task<IEnumerable<TSource>> AsEnumerable<TSource>(this Task<TSource[]> task) =>
        await task;
}

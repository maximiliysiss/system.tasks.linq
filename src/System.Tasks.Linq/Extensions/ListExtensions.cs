using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class ListExtensions
{
    public static async Task<IEnumerable<TSource>> AsEnumerable<TSource>(this Task<List<TSource>> task) =>
        await task;
}

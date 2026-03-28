using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class IListExtensions
{
    public static async Task<IEnumerable<TSource>> AsEnumerable<TSource>(this Task<IList<TSource>> task) =>
        await task;
}

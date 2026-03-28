using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class ReadOnlyListExtensions
{
    public static async Task<IEnumerable<TSource>> AsEnumerable<TSource>(this Task<IReadOnlyList<TSource>> task) =>
        await task;
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class ReadOnlyCollectionExtensions
{
    public static async Task<IEnumerable<TSource>> AsEnumerable<TSource>(this Task<IReadOnlyCollection<TSource>> task) =>
        await task;
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class CollectionExtensions
{
    public static async Task<IEnumerable<TSource>> AsEnumerable<TSource>(this Task<ICollection<TSource>> task) =>
        await task;
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class OrderingExtensions
{
    public static async Task<IOrderedEnumerable<TSource>> OrderBy<TSource, TKey>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        IComparer<TKey>? comparer = null) =>
        (await task).OrderBy(keySelector, comparer);

    public static async Task<IOrderedEnumerable<TSource>> OrderByDescending<TSource, TKey>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        IComparer<TKey>? comparer = null) =>
        (await task).OrderByDescending(keySelector, comparer);

    public static async Task<IEnumerable<TSource>> Reverse<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).Reverse();
}

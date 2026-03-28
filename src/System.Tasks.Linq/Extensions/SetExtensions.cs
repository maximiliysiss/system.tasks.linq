using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class SetExtensions
{
    public static async Task<IEnumerable<TSource>> Concat<TSource>(
        this Task<IEnumerable<TSource>> task,
        IEnumerable<TSource> second) => (await task).Concat(second);

    public static async Task<IEnumerable<TSource>> Distinct<TSource>(
        this Task<IEnumerable<TSource>> task,
        IEqualityComparer<TSource>? comparer = null) =>
        (await task).Distinct(comparer);

    public static async Task<IEnumerable<TSource>> Except<TSource>(
        this Task<IEnumerable<TSource>> task,
        IEnumerable<TSource> second,
        IEqualityComparer<TSource>? comparer = null) =>
        (await task).Except(second, comparer);

    public static async Task<IEnumerable<TSource>> Intersect<TSource>(
        this Task<IEnumerable<TSource>> task,
        IEnumerable<TSource> second,
        IEqualityComparer<TSource>? comparer = null) =>
        (await task).Intersect(second, comparer);

    public static async Task<IEnumerable<TSource>> Union<TSource>(
        this Task<IEnumerable<TSource>> task,
        IEnumerable<TSource> second,
        IEqualityComparer<TSource>? comparer = null) =>
        (await task).Union(second, comparer);
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class FilteringExtensions
{
    public static async Task<bool> All<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).All(predicate);

    public static async Task<bool> Any<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).Any();

    public static async Task<bool> Any<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).Any(predicate);

    public static async Task<bool> Contains<TSource>(
        this Task<IEnumerable<TSource>> task,
        TSource value,
        IEqualityComparer<TSource>? comparer = null) =>
        (await task).Contains(value, comparer);

    public static async Task<bool> SequenceEqual<TSource>(
        this Task<IEnumerable<TSource>> task,
        IEnumerable<TSource> second,
        IEqualityComparer<TSource>? comparer = null) =>
        (await task).SequenceEqual(second, comparer);

    public static async Task<IEnumerable<TSource>> Where<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).Where(predicate);

    public static async Task<IEnumerable<TSource>> Where<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int, bool> predicate) => (await task).Where(predicate);
}

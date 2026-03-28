using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class ConversionExtensions
{
    public static async Task<IEnumerable<TSource>> AsEnumerable<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).AsEnumerable();

    public static async Task<IEnumerable<TResult>> Cast<TResult>(this Task<IEnumerable> task) =>
        (await task).Cast<TResult>();

    public static async Task<IEnumerable<TResult>> OfType<TResult>(this Task<IEnumerable> task) =>
        (await task).OfType<TResult>();

    public static async Task<TSource[]> ToArray<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).ToArray();

    public static async Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        IEqualityComparer<TKey>? comparer = null) where TKey : notnull =>
        (await task).ToDictionary(keySelector, comparer);

    public static async Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> elementSelector,
        IEqualityComparer<TKey>? comparer = null) where TKey : notnull =>
        (await task).ToDictionary(keySelector, elementSelector, comparer);

    public static async Task<List<TSource>> ToList<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).ToList();

    public static async Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).ToLookup(keySelector, comparer);

    public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> elementSelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).ToLookup(keySelector, elementSelector, comparer);
}

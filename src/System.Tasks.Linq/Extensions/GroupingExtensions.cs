using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class GroupingExtensions
{
    public static async Task<IEnumerable<IGrouping<TKey, TSource>>> GroupBy<TSource, TKey>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).GroupBy(keySelector, comparer);

    public static async Task<IEnumerable<IGrouping<TKey, TElement>>> GroupBy<TSource, TKey, TElement>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> elementSelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).GroupBy(keySelector, elementSelector, comparer);

    public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).GroupBy(keySelector, resultSelector, comparer);

    public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TElement, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> elementSelector,
        Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).GroupBy(keySelector, elementSelector, resultSelector, comparer);

    public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(
        this Task<IEnumerable<TOuter>> task,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

    public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(
        this Task<IEnumerable<TOuter>> task,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner, TResult> resultSelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
}

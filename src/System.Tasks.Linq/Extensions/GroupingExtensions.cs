using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class GroupingExtensions
{
    /// <summary>
    /// Awaits the task and groups the elements of the resulting sequence according to a specified key selector function,
    /// using an optional equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="comparer">An equality comparer to compare keys, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents a sequence of groupings where each grouping contains elements sharing the same key.</returns>
    public static async Task<IEnumerable<IGrouping<TKey, TSource>>> GroupBy<TSource, TKey>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).GroupBy(keySelector, comparer);

    /// <summary>
    /// Awaits the task and groups the elements of the resulting sequence according to key and element selector functions,
    /// using an optional equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by <paramref name="elementSelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="elementSelector">A function to map each source element to an element in its grouping.</param>
    /// <param name="comparer">An equality comparer to compare keys, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents a sequence of groupings of projected elements sharing the same key.</returns>
    public static async Task<IEnumerable<IGrouping<TKey, TElement>>> GroupBy<TSource, TKey, TElement>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> elementSelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).GroupBy(keySelector, elementSelector, comparer);

    /// <summary>
    /// Awaits the task and groups the elements of the resulting sequence according to a key selector function
    /// and projects each group into a result using a result selector, with an optional equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result returned by <paramref name="resultSelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="resultSelector">A function to create a result value from each group.</param>
    /// <param name="comparer">An equality comparer to compare keys, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents a sequence of result values projected from each group.</returns>
    public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        Func<TKey, IEnumerable<TSource>, TResult> resultSelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).GroupBy(keySelector, resultSelector, comparer);

    /// <summary>
    /// Awaits the task and groups the elements of the resulting sequence according to key and element selector functions,
    /// projecting each group into a result using a result selector, with an optional equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by <paramref name="elementSelector"/>.</typeparam>
    /// <typeparam name="TResult">The type of the result returned by <paramref name="resultSelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <param name="elementSelector">A function to map each source element to an element in its grouping.</param>
    /// <param name="resultSelector">A function to create a result value from each group and its projected elements.</param>
    /// <param name="comparer">An equality comparer to compare keys, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents a sequence of result values projected from each group.</returns>
    public static async Task<IEnumerable<TResult>> GroupBy<TSource, TKey, TElement, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> elementSelector,
        Func<TKey, IEnumerable<TElement>, TResult> resultSelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).GroupBy(keySelector, elementSelector, resultSelector, comparer);

    /// <summary>
    /// Awaits the task and correlates the elements of the resulting outer sequence with elements
    /// of an inner sequence based on matching keys, grouping each outer element with its corresponding
    /// inner elements using an optional equality comparer.
    /// </summary>
    /// <typeparam name="TOuter">The type of the elements in the outer sequence.</typeparam>
    /// <typeparam name="TInner">The type of the elements in the inner sequence.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
    /// <typeparam name="TResult">The type of the result returned by <paramref name="resultSelector"/>.</typeparam>
    /// <param name="task">A task whose result is the outer source sequence.</param>
    /// <param name="inner">The sequence to join to the outer sequence.</param>
    /// <param name="outerKeySelector">A function to extract the join key from each element of the outer sequence.</param>
    /// <param name="innerKeySelector">A function to extract the join key from each element of the inner sequence.</param>
    /// <param name="resultSelector">A function to create a result element from an outer element and a collection of matching inner elements.</param>
    /// <param name="comparer">An equality comparer to compare keys, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents a sequence of result elements produced by the group join.</returns>
    public static async Task<IEnumerable<TResult>> GroupJoin<TOuter, TInner, TKey, TResult>(
        this Task<IEnumerable<TOuter>> task,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, IEnumerable<TInner>, TResult> resultSelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).GroupJoin(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);

    /// <summary>
    /// Awaits the task and correlates the elements of the resulting outer sequence with elements
    /// of an inner sequence based on matching keys, using an optional equality comparer.
    /// </summary>
    /// <typeparam name="TOuter">The type of the elements in the outer sequence.</typeparam>
    /// <typeparam name="TInner">The type of the elements in the inner sequence.</typeparam>
    /// <typeparam name="TKey">The type of the keys returned by the key selector functions.</typeparam>
    /// <typeparam name="TResult">The type of the result returned by <paramref name="resultSelector"/>.</typeparam>
    /// <param name="task">A task whose result is the outer source sequence.</param>
    /// <param name="inner">The sequence to join to the outer sequence.</param>
    /// <param name="outerKeySelector">A function to extract the join key from each element of the outer sequence.</param>
    /// <param name="innerKeySelector">A function to extract the join key from each element of the inner sequence.</param>
    /// <param name="resultSelector">A function to create a result element from two matching elements.</param>
    /// <param name="comparer">An equality comparer to compare keys, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents a sequence of result elements produced by the join.</returns>
    public static async Task<IEnumerable<TResult>> Join<TOuter, TInner, TKey, TResult>(
        this Task<IEnumerable<TOuter>> task,
        IEnumerable<TInner> inner,
        Func<TOuter, TKey> outerKeySelector,
        Func<TInner, TKey> innerKeySelector,
        Func<TOuter, TInner, TResult> resultSelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task).Join(inner, outerKeySelector, innerKeySelector, resultSelector, comparer);
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class OrderingExtensions
{
    /// <summary>
    /// Awaits the task and sorts the elements of the resulting sequence in ascending order
    /// according to a key, using an optional comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparer">A comparer to compare keys, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents an <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted in ascending order.</returns>
    public static async Task<IOrderedEnumerable<TSource>> OrderBy<TSource, TKey>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        IComparer<TKey>? comparer = null) =>
        (await task).OrderBy(keySelector, comparer);

    /// <summary>
    /// Awaits the task and sorts the elements of the resulting sequence in descending order
    /// according to a key, using an optional comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparer">A comparer to compare keys, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents an <see cref="IOrderedEnumerable{TSource}"/> whose elements are sorted in descending order.</returns>
    public static async Task<IOrderedEnumerable<TSource>> OrderByDescending<TSource, TKey>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        IComparer<TKey>? comparer = null) =>
        (await task).OrderByDescending(keySelector, comparer);

    /// <summary>
    /// Awaits the task and inverts the order of the elements in the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents a sequence whose elements correspond to the source sequence in reverse order.</returns>
    public static async Task<IEnumerable<TSource>> Reverse<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).Reverse();
}

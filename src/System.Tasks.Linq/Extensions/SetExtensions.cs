using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class SetExtensions
{
    /// <summary>
    /// Awaits the task and concatenates the resulting sequence with a second sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in both sequences.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="second">The sequence to concatenate to the source sequence.</param>
    /// <returns>A task that represents a sequence that contains the elements of both sequences.</returns>
    public static async Task<IEnumerable<TSource>> Concat<TSource>(
        this Task<IEnumerable<TSource>> task,
        IEnumerable<TSource> second) => (await task).Concat(second);

    /// <summary>
    /// Awaits the task and returns distinct elements from the resulting sequence,
    /// using an optional equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="comparer">An equality comparer to compare values, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents a sequence that contains distinct elements from the source sequence.</returns>
    public static async Task<IEnumerable<TSource>> Distinct<TSource>(
        this Task<IEnumerable<TSource>> task,
        IEqualityComparer<TSource>? comparer = null) =>
        (await task).Distinct(comparer);

    /// <summary>
    /// Awaits the task and produces the set difference of the resulting sequence and a second sequence,
    /// using an optional equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in both sequences.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="second">A sequence whose elements that also occur in the source sequence will be removed.</param>
    /// <param name="comparer">An equality comparer to compare values, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents a sequence containing elements from the source that are not in <paramref name="second"/>.</returns>
    public static async Task<IEnumerable<TSource>> Except<TSource>(
        this Task<IEnumerable<TSource>> task,
        IEnumerable<TSource> second,
        IEqualityComparer<TSource>? comparer = null) =>
        (await task).Except(second, comparer);

    /// <summary>
    /// Awaits the task and produces the set intersection of the resulting sequence and a second sequence,
    /// using an optional equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in both sequences.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="second">A sequence whose distinct elements that also appear in the source sequence are returned.</param>
    /// <param name="comparer">An equality comparer to compare values, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents a sequence that contains elements that appear in both the source and <paramref name="second"/>.</returns>
    public static async Task<IEnumerable<TSource>> Intersect<TSource>(
        this Task<IEnumerable<TSource>> task,
        IEnumerable<TSource> second,
        IEqualityComparer<TSource>? comparer = null) =>
        (await task).Intersect(second, comparer);

    /// <summary>
    /// Awaits the task and produces the set union of the resulting sequence and a second sequence,
    /// using an optional equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in both sequences.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="second">A sequence whose distinct elements form the second set for the union.</param>
    /// <param name="comparer">An equality comparer to compare values, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents a sequence that contains the distinct elements from both sequences.</returns>
    public static async Task<IEnumerable<TSource>> Union<TSource>(
        this Task<IEnumerable<TSource>> task,
        IEnumerable<TSource> second,
        IEqualityComparer<TSource>? comparer = null) =>
        (await task).Union(second, comparer);
}

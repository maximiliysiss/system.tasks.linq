using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

/// <summary>
/// Provides extension methods for <c>Task&lt;IEnumerable&lt;T&gt;&gt;</c> that correspond to the
/// filtering and quantifier operators in <see cref="System.Linq.Enumerable"/>:
/// <c>All</c>, <c>Any</c>, <c>Contains</c>, <c>SequenceEqual</c>, and <c>Where</c>.
/// </summary>
public static class FilteringExtensions
{
    /// <summary>
    /// Awaits the task and determines whether all elements of the resulting sequence satisfy the predicate.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents <see langword="true"/> if every element passes the test; otherwise <see langword="false"/>.</returns>
    public static async Task<bool> All<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task.ConfigureAwait(false)).All(predicate);

    /// <summary>
    /// Awaits the task and determines whether the resulting sequence contains any elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents <see langword="true"/> if the sequence contains any elements; otherwise <see langword="false"/>.</returns>
    public static async Task<bool> Any<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task.ConfigureAwait(false)).Any();

    /// <summary>
    /// Awaits the task and determines whether any element of the resulting sequence satisfies the predicate.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents <see langword="true"/> if any element passes the test; otherwise <see langword="false"/>.</returns>
    public static async Task<bool> Any<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task.ConfigureAwait(false)).Any(predicate);

    /// <summary>
    /// Awaits the task and determines whether the resulting sequence contains the specified value,
    /// using the specified equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="value">The value to locate in the sequence.</param>
    /// <param name="comparer">An equality comparer to compare values, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents <see langword="true"/> if the value is found; otherwise <see langword="false"/>.</returns>
    public static async Task<bool> Contains<TSource>(
        this Task<IEnumerable<TSource>> task,
        TSource value,
        IEqualityComparer<TSource>? comparer = null) =>
        (await task.ConfigureAwait(false)).Contains(value, comparer);

    /// <summary>
    /// Awaits the task and determines whether the resulting sequence is equal to a second sequence
    /// by comparing elements using the specified equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in both sequences.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="second">A sequence to compare to the source sequence.</param>
    /// <param name="comparer">An equality comparer to compare elements, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents <see langword="true"/> if both sequences are equal; otherwise <see langword="false"/>.</returns>
    public static async Task<bool> SequenceEqual<TSource>(
        this Task<IEnumerable<TSource>> task,
        IEnumerable<TSource> second,
        IEqualityComparer<TSource>? comparer = null) =>
        (await task.ConfigureAwait(false)).SequenceEqual(second, comparer);

    /// <summary>
    /// Awaits the task and filters the elements of the resulting sequence based on a predicate.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents a sequence containing only the elements that satisfy the predicate.</returns>
    public static async Task<IEnumerable<TSource>> Where<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task.ConfigureAwait(false)).Where(predicate);

    /// <summary>
    /// Awaits the task and filters the elements of the resulting sequence based on a predicate
    /// that incorporates each element's index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition; the second parameter represents the zero-based index of the element.</param>
    /// <returns>A task that represents a sequence containing only the elements that satisfy the predicate.</returns>
    public static async Task<IEnumerable<TSource>> Where<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int, bool> predicate) => (await task.ConfigureAwait(false)).Where(predicate);
}

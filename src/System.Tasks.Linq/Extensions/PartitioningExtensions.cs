using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

/// <summary>
/// Provides extension methods for <c>Task&lt;IEnumerable&lt;T&gt;&gt;</c> that correspond to the
/// partitioning operators in <see cref="System.Linq.Enumerable"/>:
/// <c>Append</c>, <c>DefaultIfEmpty</c>, <c>Prepend</c>, <c>Skip</c>, <c>SkipWhile</c>,
/// <c>Take</c>, and <c>TakeWhile</c>.
/// </summary>
public static class PartitioningExtensions
{
    /// <summary>
    /// Awaits the task and appends the specified element to the end of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="element">The element to append to the sequence.</param>
    /// <returns>A task that represents a new sequence ending with <paramref name="element"/>.</returns>
    public static async Task<IEnumerable<TSource>> Append<TSource>(
        this Task<IEnumerable<TSource>> task,
        TSource element) => (await task.ConfigureAwait(false)).Append(element);

    /// <summary>
    /// Awaits the task and returns the resulting sequence, or a sequence containing the default value
    /// of <typeparamref name="TSource"/> if it is empty.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the source sequence, or a single-element sequence containing the default value if the source is empty.</returns>
    public static async Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(
        this Task<IEnumerable<TSource>> task) => (await task.ConfigureAwait(false)).DefaultIfEmpty();

    /// <summary>
    /// Awaits the task and returns the resulting sequence, or a sequence containing the specified default value
    /// if it is empty.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="defaultValue">The value to return if the sequence is empty.</param>
    /// <returns>A task that represents the source sequence, or a single-element sequence containing <paramref name="defaultValue"/> if the source is empty.</returns>
    public static async Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(
        this Task<IEnumerable<TSource>> task,
        TSource defaultValue) => (await task.ConfigureAwait(false)).DefaultIfEmpty(defaultValue);

    /// <summary>
    /// Awaits the task and prepends the specified element to the beginning of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="element">The element to prepend to the sequence.</param>
    /// <returns>A task that represents a new sequence beginning with <paramref name="element"/>.</returns>
    public static async Task<IEnumerable<TSource>> Prepend<TSource>(
        this Task<IEnumerable<TSource>> task,
        TSource element) => (await task.ConfigureAwait(false)).Prepend(element);

    /// <summary>
    /// Awaits the task and bypasses a specified number of elements in the resulting sequence
    /// and returns the remaining elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="count">The number of elements to skip before returning the remaining elements.</param>
    /// <returns>A task that represents a sequence that begins after the skipped elements.</returns>
    public static async Task<IEnumerable<TSource>> Skip<TSource>(
        this Task<IEnumerable<TSource>> task,
        int count) => (await task.ConfigureAwait(false)).Skip(count);

    /// <summary>
    /// Awaits the task and bypasses elements in the resulting sequence as long as the predicate is true,
    /// then returns the remaining elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents a sequence starting with the first element that does not satisfy the predicate.</returns>
    public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task.ConfigureAwait(false)).SkipWhile(predicate);

    /// <summary>
    /// Awaits the task and bypasses elements in the resulting sequence as long as the index-aware predicate
    /// is true, then returns the remaining elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition; the second parameter represents the zero-based index of the element.</param>
    /// <returns>A task that represents a sequence starting with the first element that does not satisfy the predicate.</returns>
    public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int, bool> predicate) => (await task.ConfigureAwait(false)).SkipWhile(predicate);

    /// <summary>
    /// Awaits the task and returns a specified number of contiguous elements from the start of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="count">The number of elements to return.</param>
    /// <returns>A task that represents a sequence containing the first <paramref name="count"/> elements.</returns>
    public static async Task<IEnumerable<TSource>> Take<TSource>(
        this Task<IEnumerable<TSource>> task,
        int count) => (await task.ConfigureAwait(false)).Take(count);

    /// <summary>
    /// Awaits the task and returns elements from the resulting sequence as long as the predicate is true.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents a sequence containing elements from the start of the source that satisfy the predicate.</returns>
    public static async Task<IEnumerable<TSource>> TakeWhile<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task.ConfigureAwait(false)).TakeWhile(predicate);

    /// <summary>
    /// Awaits the task and returns elements from the resulting sequence as long as the index-aware predicate is true.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition; the second parameter represents the zero-based index of the element.</param>
    /// <returns>A task that represents a sequence containing elements from the start of the source that satisfy the predicate.</returns>
    public static async Task<IEnumerable<TSource>> TakeWhile<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int, bool> predicate) => (await task.ConfigureAwait(false)).TakeWhile(predicate);
}

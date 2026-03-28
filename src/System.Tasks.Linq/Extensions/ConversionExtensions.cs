using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

/// <summary>
/// Provides extension methods for <c>Task&lt;IEnumerable&lt;T&gt;&gt;</c> that correspond to the
/// conversion operators in <see cref="System.Linq.Enumerable"/>:
/// <c>AsEnumerable</c>, <c>Cast</c>, <c>OfType</c>, <c>ToArray</c>, <c>ToDictionary</c>, <c>ToList</c>, and <c>ToLookup</c>.
/// </summary>
public static class ConversionExtensions
{
    /// <summary>
    /// Awaits the task and returns the resulting sequence as <see cref="IEnumerable{TSource}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the source sequence typed as <see cref="IEnumerable{TSource}"/>.</returns>
    public static async Task<IEnumerable<TSource>> AsEnumerable<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task.ConfigureAwait(false)).AsEnumerable();

    /// <summary>
    /// Awaits the task and casts each element of the resulting non-generic sequence to the specified type.
    /// </summary>
    /// <typeparam name="TResult">The type to cast the elements to.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents a sequence of elements cast to <typeparamref name="TResult"/>.</returns>
    public static async Task<IEnumerable<TResult>> Cast<TResult>(this Task<IEnumerable> task) =>
        (await task.ConfigureAwait(false)).Cast<TResult>();

    /// <summary>
    /// Awaits the task and filters the elements of the resulting non-generic sequence based on the specified type.
    /// </summary>
    /// <typeparam name="TResult">The type to filter the elements on.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents a sequence containing only elements of type <typeparamref name="TResult"/>.</returns>
    public static async Task<IEnumerable<TResult>> OfType<TResult>(this Task<IEnumerable> task) =>
        (await task.ConfigureAwait(false)).OfType<TResult>();

    /// <summary>
    /// Awaits the task and converts the resulting sequence to an array.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents an array containing the elements of the sequence.</returns>
    public static async Task<TSource[]> ToArray<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task.ConfigureAwait(false)).ToArray();

    /// <summary>
    /// Awaits the task and creates a <see cref="Dictionary{TKey, TSource}"/> from the resulting sequence
    /// according to a specified key selector function and optional equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparer">An equality comparer to compare keys, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents a <see cref="Dictionary{TKey, TSource}"/> that contains keys and values.</returns>
    public static async Task<Dictionary<TKey, TSource>> ToDictionary<TSource, TKey>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        IEqualityComparer<TKey>? comparer = null) where TKey : notnull =>
        (await task.ConfigureAwait(false)).ToDictionary(keySelector, comparer);

    /// <summary>
    /// Awaits the task and creates a <see cref="Dictionary{TKey, TElement}"/> from the resulting sequence
    /// according to specified key selector and element selector functions and an optional equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by <paramref name="elementSelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparer">An equality comparer to compare keys, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents a <see cref="Dictionary{TKey, TElement}"/> that contains keys and values.</returns>
    public static async Task<Dictionary<TKey, TElement>> ToDictionary<TSource, TKey, TElement>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> elementSelector,
        IEqualityComparer<TKey>? comparer = null) where TKey : notnull =>
        (await task.ConfigureAwait(false)).ToDictionary(keySelector, elementSelector, comparer);

    /// <summary>
    /// Awaits the task and creates a <see cref="List{TSource}"/> from the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents a <see cref="List{TSource}"/> containing the elements of the sequence.</returns>
    public static async Task<List<TSource>> ToList<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task.ConfigureAwait(false)).ToList();

    /// <summary>
    /// Awaits the task and creates an <see cref="ILookup{TKey, TSource}"/> from the resulting sequence
    /// according to a specified key selector function and optional equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="comparer">An equality comparer to compare keys, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents an <see cref="ILookup{TKey, TSource}"/> that contains keys and values.</returns>
    public static async Task<ILookup<TKey, TSource>> ToLookup<TSource, TKey>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task.ConfigureAwait(false)).ToLookup(keySelector, comparer);

    /// <summary>
    /// Awaits the task and creates an <see cref="ILookup{TKey, TElement}"/> from the resulting sequence
    /// according to specified key selector and element selector functions and an optional equality comparer.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
    /// <typeparam name="TElement">The type of the value returned by <paramref name="elementSelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="keySelector">A function to extract a key from each element.</param>
    /// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
    /// <param name="comparer">An equality comparer to compare keys, or <see langword="null"/> to use the default comparer.</param>
    /// <returns>A task that represents an <see cref="ILookup{TKey, TElement}"/> that contains keys and values.</returns>
    public static async Task<ILookup<TKey, TElement>> ToLookup<TSource, TKey, TElement>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TKey> keySelector,
        Func<TSource, TElement> elementSelector,
        IEqualityComparer<TKey>? comparer = null) =>
        (await task.ConfigureAwait(false)).ToLookup(keySelector, elementSelector, comparer);
}

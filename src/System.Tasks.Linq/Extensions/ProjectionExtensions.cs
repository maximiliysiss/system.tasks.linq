using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

/// <summary>
/// Provides extension methods for <c>Task&lt;IEnumerable&lt;T&gt;&gt;</c> that correspond to the
/// projection operators in <see cref="System.Linq.Enumerable"/>:
/// <c>Select</c> and <c>SelectMany</c>.
/// </summary>
public static class ProjectionExtensions
{
    /// <summary>
    /// Awaits the task and projects each element of the resulting sequence into a new form.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents a sequence of projected elements.</returns>
    public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TResult> selector) => (await task).Select(selector);

    /// <summary>
    /// Awaits the task and projects each element of the resulting sequence into a new form
    /// by incorporating each element's index.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element; the second parameter represents the zero-based index of the element.</param>
    /// <returns>A task that represents a sequence of projected elements.</returns>
    public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int, TResult> selector) => (await task).Select(selector);

    /// <summary>
    /// Awaits the task and projects each element of the resulting sequence to an <see cref="IEnumerable{TResult}"/>
    /// and flattens the resulting sequences into one sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TResult">The type of the elements of the sequences returned by <paramref name="selector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents a flattened sequence of projected elements.</returns>
    public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, IEnumerable<TResult>> selector) => (await task).SelectMany(selector);

    /// <summary>
    /// Awaits the task and projects each element of the resulting sequence to an <see cref="IEnumerable{TResult}"/>
    /// by incorporating each element's index, and flattens the resulting sequences into one sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TResult">The type of the elements of the sequences returned by <paramref name="selector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element; the second parameter represents the zero-based index of the element.</param>
    /// <returns>A task that represents a flattened sequence of projected elements.</returns>
    public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int, IEnumerable<TResult>> selector) => (await task).SelectMany(selector);

    /// <summary>
    /// Awaits the task and projects each element of the resulting sequence to an intermediate collection,
    /// then applies a result selector to each pair of source element and collection element.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TCollection">The type of the intermediate elements collected by <paramref name="collectionSelector"/>.</typeparam>
    /// <typeparam name="TResult">The type of the elements returned by <paramref name="resultSelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="collectionSelector">A transform function to apply to each element to produce an intermediate sequence.</param>
    /// <param name="resultSelector">A transform function to apply to each element of the intermediate sequence.</param>
    /// <returns>A task that represents a sequence whose elements are the result of invoking the result selector on each pair.</returns>
    public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, IEnumerable<TCollection>> collectionSelector,
        Func<TSource, TCollection, TResult> resultSelector) =>
        (await task).SelectMany(collectionSelector, resultSelector);

    /// <summary>
    /// Awaits the task and projects each element of the resulting sequence to an intermediate collection
    /// by incorporating each element's index, then applies a result selector to each pair.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TCollection">The type of the intermediate elements collected by <paramref name="collectionSelector"/>.</typeparam>
    /// <typeparam name="TResult">The type of the elements returned by <paramref name="resultSelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="collectionSelector">A transform function to apply to each element to produce an intermediate sequence; the second parameter represents the zero-based index of the source element.</param>
    /// <param name="resultSelector">A transform function to apply to each element of the intermediate sequence.</param>
    /// <returns>A task that represents a sequence whose elements are the result of invoking the result selector on each pair.</returns>
    public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
        Func<TSource, TCollection, TResult> resultSelector) =>
        (await task).SelectMany(collectionSelector, resultSelector);
}

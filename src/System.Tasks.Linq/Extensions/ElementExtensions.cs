using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class ElementExtensions
{
    /// <summary>
    /// Awaits the task and returns the element at the specified index in the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <returns>A task that represents the element at the specified position in the sequence.</returns>
    /// <exception cref="ArgumentOutOfRangeException"><paramref name="index"/> is less than 0 or greater than or equal to the number of elements in the sequence.</exception>
    public static async Task<TSource> ElementAt<TSource>(this Task<IEnumerable<TSource>> task, int index) =>
        (await task).ElementAt(index);

    /// <summary>
    /// Awaits the task and returns the element at the specified index in the resulting sequence,
    /// or a default value if the index is out of range.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="index">The zero-based index of the element to retrieve.</param>
    /// <returns>A task that represents the element at the specified position, or the default value of <typeparamref name="TSource"/> if the index is out of range.</returns>
    public static async Task<TSource?> ElementAtOrDefault<TSource>(this Task<IEnumerable<TSource>> task, int index) =>
        (await task).ElementAtOrDefault(index);

    /// <summary>
    /// Awaits the task and returns the first element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the first element of the sequence.</returns>
    /// <exception cref="InvalidOperationException">The source sequence contains no elements.</exception>
    public static async Task<TSource> First<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).First();

    /// <summary>
    /// Awaits the task and returns the first element in the resulting sequence that satisfies the predicate.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents the first element that passes the test.</returns>
    /// <exception cref="InvalidOperationException">No element satisfies the condition, or the source sequence contains no elements.</exception>
    public static async Task<TSource> First<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).First(predicate);

    /// <summary>
    /// Awaits the task and returns the first element of the resulting sequence, or a default value
    /// if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the first element, or the default value of <typeparamref name="TSource"/> if the sequence is empty.</returns>
    public static async Task<TSource?> FirstOrDefault<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).FirstOrDefault();

    /// <summary>
    /// Awaits the task and returns the first element in the resulting sequence that satisfies the predicate,
    /// or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents the first matching element, or the default value of <typeparamref name="TSource"/> if none is found.</returns>
    public static async Task<TSource?> FirstOrDefault<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).FirstOrDefault(predicate);

    /// <summary>
    /// Awaits the task and returns the last element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the last element of the sequence.</returns>
    /// <exception cref="InvalidOperationException">The source sequence contains no elements.</exception>
    public static async Task<TSource> Last<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).Last();

    /// <summary>
    /// Awaits the task and returns the last element in the resulting sequence that satisfies the predicate.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents the last element that passes the test.</returns>
    /// <exception cref="InvalidOperationException">No element satisfies the condition, or the source sequence contains no elements.</exception>
    public static async Task<TSource> Last<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).Last(predicate);

    /// <summary>
    /// Awaits the task and returns the last element of the resulting sequence, or a default value
    /// if the sequence contains no elements.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the last element, or the default value of <typeparamref name="TSource"/> if the sequence is empty.</returns>
    public static async Task<TSource?> LastOrDefault<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).LastOrDefault();

    /// <summary>
    /// Awaits the task and returns the last element in the resulting sequence that satisfies the predicate,
    /// or a default value if no such element is found.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents the last matching element, or the default value of <typeparamref name="TSource"/> if none is found.</returns>
    public static async Task<TSource?> LastOrDefault<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).LastOrDefault(predicate);

    /// <summary>
    /// Awaits the task and returns the only element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the single element of the sequence.</returns>
    /// <exception cref="InvalidOperationException">The source sequence is empty or contains more than one element.</exception>
    public static async Task<TSource> Single<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).Single();

    /// <summary>
    /// Awaits the task and returns the only element in the resulting sequence that satisfies the predicate.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents the single element that passes the test.</returns>
    /// <exception cref="InvalidOperationException">No element satisfies the condition, more than one element satisfies the condition, or the source sequence contains no elements.</exception>
    public static async Task<TSource> Single<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).Single(predicate);

    /// <summary>
    /// Awaits the task and returns the only element of the resulting sequence, or a default value
    /// if the sequence is empty.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the single element, or the default value of <typeparamref name="TSource"/> if the sequence is empty.</returns>
    /// <exception cref="InvalidOperationException">The source sequence contains more than one element.</exception>
    public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).SingleOrDefault();

    /// <summary>
    /// Awaits the task and returns the only element in the resulting sequence that satisfies the predicate,
    /// or a default value if no such element exists.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents the single matching element, or the default value of <typeparamref name="TSource"/> if none is found.</returns>
    /// <exception cref="InvalidOperationException">More than one element satisfies the condition.</exception>
    public static async Task<TSource?> SingleOrDefault<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).SingleOrDefault(predicate);
}

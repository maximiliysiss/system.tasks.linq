using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

/// <summary>
/// Provides extension methods for <c>Task&lt;IEnumerable&lt;T&gt;&gt;</c> that correspond to the
/// aggregation operators in <see cref="System.Linq.Enumerable"/>:
/// <c>Aggregate</c>, <c>Average</c>, <c>Count</c>, <c>LongCount</c>, <c>Max</c>, <c>Min</c>, and <c>Sum</c>.
/// </summary>
public static class AggregationExtensions
{
    /// <summary>
    /// Awaits the task and applies an accumulator function over the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <returns>A task that represents the final accumulator value.</returns>
    /// <exception cref="InvalidOperationException">The source sequence contains no elements.</exception>
    public static async Task<TSource> Aggregate<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TSource, TSource> func) => (await task.ConfigureAwait(false)).Aggregate(func);

    /// <summary>
    /// Awaits the task and applies an accumulator function over the resulting sequence,
    /// using the specified seed value.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <returns>A task that represents the final accumulator value.</returns>
    public static async Task<TAccumulate> Aggregate<TSource, TAccumulate>(
        this Task<IEnumerable<TSource>> task,
        TAccumulate seed,
        Func<TAccumulate, TSource, TAccumulate> func) =>
        (await task.ConfigureAwait(false)).Aggregate(seed, func);

    /// <summary>
    /// Awaits the task and applies an accumulator function over the resulting sequence,
    /// using the specified seed value and result selector.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TAccumulate">The type of the accumulator value.</typeparam>
    /// <typeparam name="TResult">The type of the resulting value.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="seed">The initial accumulator value.</param>
    /// <param name="func">An accumulator function to be invoked on each element.</param>
    /// <param name="resultSelector">A function to transform the final accumulator value into the result value.</param>
    /// <returns>A task that represents the transformed final accumulator value.</returns>
    public static async Task<TResult> Aggregate<TSource, TAccumulate, TResult>(
        this Task<IEnumerable<TSource>> task,
        TAccumulate seed,
        Func<TAccumulate, TSource, TAccumulate> func,
        Func<TAccumulate, TResult> resultSelector) =>
        (await task.ConfigureAwait(false)).Aggregate(seed, func, resultSelector);

    /// <summary>
    /// Awaits the task and computes the average of the resulting sequence of <see cref="double"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the average of the sequence.</returns>
    public static async Task<double> Average(this Task<IEnumerable<double>> task) => (await task.ConfigureAwait(false)).Average();

    /// <summary>
    /// Awaits the task and computes the average of the resulting sequence of <see cref="int"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the average of the sequence.</returns>
    public static async Task<double> Average(this Task<IEnumerable<int>> task) => (await task.ConfigureAwait(false)).Average();

    /// <summary>
    /// Awaits the task and computes the average of the resulting sequence of <see cref="long"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the average of the sequence.</returns>
    public static async Task<double> Average(this Task<IEnumerable<long>> task) => (await task.ConfigureAwait(false)).Average();

    /// <summary>
    /// Awaits the task and computes the average of the resulting sequence of <see cref="float"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the average of the sequence.</returns>
    public static async Task<float> Average(this Task<IEnumerable<float>> task) => (await task.ConfigureAwait(false)).Average();

    /// <summary>
    /// Awaits the task and computes the average of the resulting sequence of <see cref="decimal"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the average of the sequence.</returns>
    public static async Task<decimal> Average(this Task<IEnumerable<decimal>> task) => (await task.ConfigureAwait(false)).Average();

    /// <summary>
    /// Awaits the task and computes the average of the resulting sequence of nullable <see cref="decimal"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the average of the non-null elements, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<decimal?> Average(this Task<IEnumerable<decimal?>> task) => (await task.ConfigureAwait(false)).Average();

    /// <summary>
    /// Awaits the task and computes the average of the resulting sequence of nullable <see cref="double"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the average of the non-null elements, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<double?> Average(this Task<IEnumerable<double?>> task) => (await task.ConfigureAwait(false)).Average();

    /// <summary>
    /// Awaits the task and computes the average of the resulting sequence of nullable <see cref="int"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the average of the non-null elements, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<double?> Average(this Task<IEnumerable<int?>> task) => (await task.ConfigureAwait(false)).Average();

    /// <summary>
    /// Awaits the task and computes the average of the resulting sequence of nullable <see cref="long"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the average of the non-null elements, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<double?> Average(this Task<IEnumerable<long?>> task) => (await task.ConfigureAwait(false)).Average();

    /// <summary>
    /// Awaits the task and computes the average of the resulting sequence of nullable <see cref="float"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the average of the non-null elements, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<float?> Average(this Task<IEnumerable<float?>> task) => (await task.ConfigureAwait(false)).Average();

    /// <summary>
    /// Awaits the task and computes the average of the <see cref="double"/> values obtained by
    /// invoking a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the average of the projected values.</returns>
    public static async Task<double> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double> selector) => (await task.ConfigureAwait(false)).Average(selector);

    /// <summary>
    /// Awaits the task and computes the average of the <see cref="int"/> values obtained by
    /// invoking a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the average of the projected values.</returns>
    public static async Task<double> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int> selector) => (await task.ConfigureAwait(false)).Average(selector);

    /// <summary>
    /// Awaits the task and computes the average of the <see cref="long"/> values obtained by
    /// invoking a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the average of the projected values.</returns>
    public static async Task<double> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long> selector) => (await task.ConfigureAwait(false)).Average(selector);

    /// <summary>
    /// Awaits the task and computes the average of the <see cref="float"/> values obtained by
    /// invoking a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the average of the projected values.</returns>
    public static async Task<float> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float> selector) => (await task.ConfigureAwait(false)).Average(selector);

    /// <summary>
    /// Awaits the task and computes the average of the <see cref="decimal"/> values obtained by
    /// invoking a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the average of the projected values.</returns>
    public static async Task<decimal> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal> selector) => (await task.ConfigureAwait(false)).Average(selector);

    /// <summary>
    /// Awaits the task and computes the average of the nullable <see cref="decimal"/> values obtained by
    /// invoking a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the average of the projected non-null values, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<decimal?> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal?> selector) => (await task.ConfigureAwait(false)).Average(selector);

    /// <summary>
    /// Awaits the task and computes the average of the nullable <see cref="double"/> values obtained by
    /// invoking a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the average of the projected non-null values, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<double?> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double?> selector) => (await task.ConfigureAwait(false)).Average(selector);

    /// <summary>
    /// Awaits the task and computes the average of the nullable <see cref="int"/> values obtained by
    /// invoking a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the average of the projected non-null values, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<double?> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int?> selector) => (await task.ConfigureAwait(false)).Average(selector);

    /// <summary>
    /// Awaits the task and computes the average of the nullable <see cref="long"/> values obtained by
    /// invoking a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the average of the projected non-null values, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<double?> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long?> selector) => (await task.ConfigureAwait(false)).Average(selector);

    /// <summary>
    /// Awaits the task and computes the average of the nullable <see cref="float"/> values obtained by
    /// invoking a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the average of the projected non-null values, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<float?> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float?> selector) => (await task.ConfigureAwait(false)).Average(selector);

    /// <summary>
    /// Awaits the task and returns the number of elements in the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the number of elements in the sequence.</returns>
    public static async Task<int> Count<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task.ConfigureAwait(false)).Count();

    /// <summary>
    /// Awaits the task and returns the number of elements in the resulting sequence that satisfy the predicate.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents the number of elements satisfying the predicate.</returns>
    public static async Task<int> Count<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task.ConfigureAwait(false)).Count(predicate);

    /// <summary>
    /// Awaits the task and returns the number of elements in the resulting sequence as a <see cref="long"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the number of elements in the sequence.</returns>
    public static async Task<long> LongCount<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task.ConfigureAwait(false)).LongCount();

    /// <summary>
    /// Awaits the task and returns the number of elements in the resulting sequence that satisfy the predicate, as a <see cref="long"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A task that represents the number of elements satisfying the predicate.</returns>
    public static async Task<long> LongCount<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task.ConfigureAwait(false)).LongCount(predicate);

    /// <summary>
    /// Awaits the task and returns the maximum <see cref="double"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the maximum value in the sequence.</returns>
    public static async Task<double> Max(this Task<IEnumerable<double>> task) => (await task.ConfigureAwait(false)).Max();

    /// <summary>
    /// Awaits the task and returns the maximum <see cref="int"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the maximum value in the sequence.</returns>
    public static async Task<int> Max(this Task<IEnumerable<int>> task) => (await task.ConfigureAwait(false)).Max();

    /// <summary>
    /// Awaits the task and returns the maximum <see cref="long"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the maximum value in the sequence.</returns>
    public static async Task<long> Max(this Task<IEnumerable<long>> task) => (await task.ConfigureAwait(false)).Max();

    /// <summary>
    /// Awaits the task and returns the maximum <see cref="float"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the maximum value in the sequence.</returns>
    public static async Task<float> Max(this Task<IEnumerable<float>> task) => (await task.ConfigureAwait(false)).Max();

    /// <summary>
    /// Awaits the task and returns the maximum <see cref="decimal"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the maximum value in the sequence.</returns>
    public static async Task<decimal> Max(this Task<IEnumerable<decimal>> task) => (await task.ConfigureAwait(false)).Max();

    /// <summary>
    /// Awaits the task and returns the maximum nullable <see cref="decimal"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the maximum value in the sequence, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<decimal?> Max(this Task<IEnumerable<decimal?>> task) => (await task.ConfigureAwait(false)).Max();

    /// <summary>
    /// Awaits the task and returns the maximum nullable <see cref="double"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the maximum value in the sequence, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<double?> Max(this Task<IEnumerable<double?>> task) => (await task.ConfigureAwait(false)).Max();

    /// <summary>
    /// Awaits the task and returns the maximum nullable <see cref="int"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the maximum value in the sequence, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<int?> Max(this Task<IEnumerable<int?>> task) => (await task.ConfigureAwait(false)).Max();

    /// <summary>
    /// Awaits the task and returns the maximum nullable <see cref="long"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the maximum value in the sequence, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<long?> Max(this Task<IEnumerable<long?>> task) => (await task.ConfigureAwait(false)).Max();

    /// <summary>
    /// Awaits the task and returns the maximum nullable <see cref="float"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the maximum value in the sequence, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<float?> Max(this Task<IEnumerable<float?>> task) => (await task.ConfigureAwait(false)).Max();

    /// <summary>
    /// Awaits the task and returns the maximum element from the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the maximum element in the sequence.</returns>
    public static async Task<TSource?> Max<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task.ConfigureAwait(false)).Max();

    /// <summary>
    /// Awaits the task and returns the maximum <see cref="double"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the maximum projected value.</returns>
    public static async Task<double> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double> selector) => (await task.ConfigureAwait(false)).Max(selector);

    /// <summary>
    /// Awaits the task and returns the maximum <see cref="int"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the maximum projected value.</returns>
    public static async Task<int> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int> selector) => (await task.ConfigureAwait(false)).Max(selector);

    /// <summary>
    /// Awaits the task and returns the maximum <see cref="long"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the maximum projected value.</returns>
    public static async Task<long> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long> selector) => (await task.ConfigureAwait(false)).Max(selector);

    /// <summary>
    /// Awaits the task and returns the maximum <see cref="float"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the maximum projected value.</returns>
    public static async Task<float> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float> selector) => (await task.ConfigureAwait(false)).Max(selector);

    /// <summary>
    /// Awaits the task and returns the maximum <see cref="decimal"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the maximum projected value.</returns>
    public static async Task<decimal> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal> selector) => (await task.ConfigureAwait(false)).Max(selector);

    /// <summary>
    /// Awaits the task and returns the maximum nullable <see cref="decimal"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the maximum projected value, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<decimal?> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal?> selector) => (await task.ConfigureAwait(false)).Max(selector);

    /// <summary>
    /// Awaits the task and returns the maximum nullable <see cref="double"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the maximum projected value, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<double?> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double?> selector) => (await task.ConfigureAwait(false)).Max(selector);

    /// <summary>
    /// Awaits the task and returns the maximum nullable <see cref="int"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the maximum projected value, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<int?> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int?> selector) => (await task.ConfigureAwait(false)).Max(selector);

    /// <summary>
    /// Awaits the task and returns the maximum nullable <see cref="long"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the maximum projected value, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<long?> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long?> selector) => (await task.ConfigureAwait(false)).Max(selector);

    /// <summary>
    /// Awaits the task and returns the maximum nullable <see cref="float"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the maximum projected value, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<float?> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float?> selector) => (await task.ConfigureAwait(false)).Max(selector);

    /// <summary>
    /// Awaits the task and returns the maximum projected value obtained by invoking a selector function
    /// on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the maximum projected value.</returns>
    public static async Task<TResult?> Max<TSource, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TResult> selector) => (await task.ConfigureAwait(false)).Max(selector);

    /// <summary>
    /// Awaits the task and returns the minimum <see cref="double"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the minimum value in the sequence.</returns>
    public static async Task<double> Min(this Task<IEnumerable<double>> task) => (await task.ConfigureAwait(false)).Min();

    /// <summary>
    /// Awaits the task and returns the minimum <see cref="int"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the minimum value in the sequence.</returns>
    public static async Task<int> Min(this Task<IEnumerable<int>> task) => (await task.ConfigureAwait(false)).Min();

    /// <summary>
    /// Awaits the task and returns the minimum <see cref="long"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the minimum value in the sequence.</returns>
    public static async Task<long> Min(this Task<IEnumerable<long>> task) => (await task.ConfigureAwait(false)).Min();

    /// <summary>
    /// Awaits the task and returns the minimum <see cref="float"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the minimum value in the sequence.</returns>
    public static async Task<float> Min(this Task<IEnumerable<float>> task) => (await task.ConfigureAwait(false)).Min();

    /// <summary>
    /// Awaits the task and returns the minimum <see cref="decimal"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the minimum value in the sequence.</returns>
    public static async Task<decimal> Min(this Task<IEnumerable<decimal>> task) => (await task.ConfigureAwait(false)).Min();

    /// <summary>
    /// Awaits the task and returns the minimum nullable <see cref="decimal"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the minimum value in the sequence, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<decimal?> Min(this Task<IEnumerable<decimal?>> task) => (await task.ConfigureAwait(false)).Min();

    /// <summary>
    /// Awaits the task and returns the minimum nullable <see cref="double"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the minimum value in the sequence, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<double?> Min(this Task<IEnumerable<double?>> task) => (await task.ConfigureAwait(false)).Min();

    /// <summary>
    /// Awaits the task and returns the minimum nullable <see cref="int"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the minimum value in the sequence, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<int?> Min(this Task<IEnumerable<int?>> task) => (await task.ConfigureAwait(false)).Min();

    /// <summary>
    /// Awaits the task and returns the minimum nullable <see cref="long"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the minimum value in the sequence, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<long?> Min(this Task<IEnumerable<long?>> task) => (await task.ConfigureAwait(false)).Min();

    /// <summary>
    /// Awaits the task and returns the minimum nullable <see cref="float"/> value in the resulting sequence.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the minimum value in the sequence, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<float?> Min(this Task<IEnumerable<float?>> task) => (await task.ConfigureAwait(false)).Min();

    /// <summary>
    /// Awaits the task and returns the minimum element from the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the minimum element in the sequence.</returns>
    public static async Task<TSource?> Min<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task.ConfigureAwait(false)).Min();

    /// <summary>
    /// Awaits the task and returns the minimum <see cref="double"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the minimum projected value.</returns>
    public static async Task<double> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double> selector) => (await task.ConfigureAwait(false)).Min(selector);

    /// <summary>
    /// Awaits the task and returns the minimum <see cref="int"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the minimum projected value.</returns>
    public static async Task<int> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int> selector) => (await task.ConfigureAwait(false)).Min(selector);

    /// <summary>
    /// Awaits the task and returns the minimum <see cref="long"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the minimum projected value.</returns>
    public static async Task<long> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long> selector) => (await task.ConfigureAwait(false)).Min(selector);

    /// <summary>
    /// Awaits the task and returns the minimum <see cref="float"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the minimum projected value.</returns>
    public static async Task<float> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float> selector) => (await task.ConfigureAwait(false)).Min(selector);

    /// <summary>
    /// Awaits the task and returns the minimum <see cref="decimal"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the minimum projected value.</returns>
    public static async Task<decimal> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal> selector) => (await task.ConfigureAwait(false)).Min(selector);

    /// <summary>
    /// Awaits the task and returns the minimum nullable <see cref="decimal"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the minimum projected value, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<decimal?> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal?> selector) => (await task.ConfigureAwait(false)).Min(selector);

    /// <summary>
    /// Awaits the task and returns the minimum nullable <see cref="double"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the minimum projected value, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<double?> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double?> selector) => (await task.ConfigureAwait(false)).Min(selector);

    /// <summary>
    /// Awaits the task and returns the minimum nullable <see cref="int"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the minimum projected value, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<int?> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int?> selector) => (await task.ConfigureAwait(false)).Min(selector);

    /// <summary>
    /// Awaits the task and returns the minimum nullable <see cref="long"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the minimum projected value, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<long?> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long?> selector) => (await task.ConfigureAwait(false)).Min(selector);

    /// <summary>
    /// Awaits the task and returns the minimum nullable <see cref="float"/> value obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the minimum projected value, or <see langword="null"/> if the sequence is empty or contains only nulls.</returns>
    public static async Task<float?> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float?> selector) => (await task.ConfigureAwait(false)).Min(selector);

    /// <summary>
    /// Awaits the task and returns the minimum projected value obtained by invoking a selector function
    /// on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the minimum projected value.</returns>
    public static async Task<TResult?> Min<TSource, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TResult> selector) => (await task.ConfigureAwait(false)).Min(selector);

    /// <summary>
    /// Awaits the task and computes the sum of the resulting sequence of <see cref="double"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the sum of the values in the sequence.</returns>
    public static async Task<double> Sum(this Task<IEnumerable<double>> task) => (await task.ConfigureAwait(false)).Sum();

    /// <summary>
    /// Awaits the task and computes the sum of the resulting sequence of <see cref="int"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the sum of the values in the sequence.</returns>
    public static async Task<int> Sum(this Task<IEnumerable<int>> task) => (await task.ConfigureAwait(false)).Sum();

    /// <summary>
    /// Awaits the task and computes the sum of the resulting sequence of <see cref="long"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the sum of the values in the sequence.</returns>
    public static async Task<long> Sum(this Task<IEnumerable<long>> task) => (await task.ConfigureAwait(false)).Sum();

    /// <summary>
    /// Awaits the task and computes the sum of the resulting sequence of <see cref="float"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the sum of the values in the sequence.</returns>
    public static async Task<float> Sum(this Task<IEnumerable<float>> task) => (await task.ConfigureAwait(false)).Sum();

    /// <summary>
    /// Awaits the task and computes the sum of the resulting sequence of <see cref="decimal"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the sum of the values in the sequence.</returns>
    public static async Task<decimal> Sum(this Task<IEnumerable<decimal>> task) => (await task.ConfigureAwait(false)).Sum();

    /// <summary>
    /// Awaits the task and computes the sum of the resulting sequence of nullable <see cref="decimal"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the sum of the non-null values in the sequence.</returns>
    public static async Task<decimal?> Sum(this Task<IEnumerable<decimal?>> task) => (await task.ConfigureAwait(false)).Sum();

    /// <summary>
    /// Awaits the task and computes the sum of the resulting sequence of nullable <see cref="double"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the sum of the non-null values in the sequence.</returns>
    public static async Task<double?> Sum(this Task<IEnumerable<double?>> task) => (await task.ConfigureAwait(false)).Sum();

    /// <summary>
    /// Awaits the task and computes the sum of the resulting sequence of nullable <see cref="int"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the sum of the non-null values in the sequence.</returns>
    public static async Task<int?> Sum(this Task<IEnumerable<int?>> task) => (await task.ConfigureAwait(false)).Sum();

    /// <summary>
    /// Awaits the task and computes the sum of the resulting sequence of nullable <see cref="long"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the sum of the non-null values in the sequence.</returns>
    public static async Task<long?> Sum(this Task<IEnumerable<long?>> task) => (await task.ConfigureAwait(false)).Sum();

    /// <summary>
    /// Awaits the task and computes the sum of the resulting sequence of nullable <see cref="float"/> values.
    /// </summary>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the sum of the non-null values in the sequence.</returns>
    public static async Task<float?> Sum(this Task<IEnumerable<float?>> task) => (await task.ConfigureAwait(false)).Sum();

    /// <summary>
    /// Awaits the task and computes the sum of the <see cref="double"/> values obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the sum of the projected values.</returns>
    public static async Task<double> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double> selector) => (await task.ConfigureAwait(false)).Sum(selector);

    /// <summary>
    /// Awaits the task and computes the sum of the <see cref="int"/> values obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the sum of the projected values.</returns>
    public static async Task<int> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int> selector) => (await task.ConfigureAwait(false)).Sum(selector);

    /// <summary>
    /// Awaits the task and computes the sum of the <see cref="long"/> values obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the sum of the projected values.</returns>
    public static async Task<long> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long> selector) => (await task.ConfigureAwait(false)).Sum(selector);

    /// <summary>
    /// Awaits the task and computes the sum of the <see cref="float"/> values obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the sum of the projected values.</returns>
    public static async Task<float> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float> selector) => (await task.ConfigureAwait(false)).Sum(selector);

    /// <summary>
    /// Awaits the task and computes the sum of the <see cref="decimal"/> values obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the sum of the projected values.</returns>
    public static async Task<decimal> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal> selector) => (await task.ConfigureAwait(false)).Sum(selector);

    /// <summary>
    /// Awaits the task and computes the sum of the nullable <see cref="decimal"/> values obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the sum of the projected non-null values.</returns>
    public static async Task<decimal?> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal?> selector) => (await task.ConfigureAwait(false)).Sum(selector);

    /// <summary>
    /// Awaits the task and computes the sum of the nullable <see cref="double"/> values obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the sum of the projected non-null values.</returns>
    public static async Task<double?> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double?> selector) => (await task.ConfigureAwait(false)).Sum(selector);

    /// <summary>
    /// Awaits the task and computes the sum of the nullable <see cref="int"/> values obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the sum of the projected non-null values.</returns>
    public static async Task<int?> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int?> selector) => (await task.ConfigureAwait(false)).Sum(selector);

    /// <summary>
    /// Awaits the task and computes the sum of the nullable <see cref="long"/> values obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the sum of the projected non-null values.</returns>
    public static async Task<long?> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long?> selector) => (await task.ConfigureAwait(false)).Sum(selector);

    /// <summary>
    /// Awaits the task and computes the sum of the nullable <see cref="float"/> values obtained by invoking
    /// a selector function on each element of the resulting sequence.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="selector">A transform function to apply to each element.</param>
    /// <returns>A task that represents the sum of the projected non-null values.</returns>
    public static async Task<float?> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float?> selector) => (await task.ConfigureAwait(false)).Sum(selector);
}

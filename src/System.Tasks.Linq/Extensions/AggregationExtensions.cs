using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class AggregationExtensions
{
    public static async Task<TSource> Aggregate<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TSource, TSource> func) => (await task).Aggregate(func);

    public static async Task<TAccumulate> Aggregate<TSource, TAccumulate>(
        this Task<IEnumerable<TSource>> task,
        TAccumulate seed,
        Func<TAccumulate, TSource, TAccumulate> func) =>
        (await task).Aggregate(seed, func);

    public static async Task<TResult> Aggregate<TSource, TAccumulate, TResult>(
        this Task<IEnumerable<TSource>> task,
        TAccumulate seed,
        Func<TAccumulate, TSource, TAccumulate> func,
        Func<TAccumulate, TResult> resultSelector) =>
        (await task).Aggregate(seed, func, resultSelector);

    public static async Task<double> Average(this Task<IEnumerable<double>> task) => (await task).Average();
    public static async Task<double> Average(this Task<IEnumerable<int>> task) => (await task).Average();
    public static async Task<double> Average(this Task<IEnumerable<long>> task) => (await task).Average();
    public static async Task<float> Average(this Task<IEnumerable<float>> task) => (await task).Average();
    public static async Task<decimal> Average(this Task<IEnumerable<decimal>> task) => (await task).Average();
    public static async Task<decimal?> Average(this Task<IEnumerable<decimal?>> task) => (await task).Average();
    public static async Task<double?> Average(this Task<IEnumerable<double?>> task) => (await task).Average();
    public static async Task<double?> Average(this Task<IEnumerable<int?>> task) => (await task).Average();
    public static async Task<double?> Average(this Task<IEnumerable<long?>> task) => (await task).Average();
    public static async Task<float?> Average(this Task<IEnumerable<float?>> task) => (await task).Average();

    public static async Task<double> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double> selector) => (await task).Average(selector);

    public static async Task<double> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int> selector) => (await task).Average(selector);

    public static async Task<double> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long> selector) => (await task).Average(selector);

    public static async Task<float> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float> selector) => (await task).Average(selector);

    public static async Task<decimal> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal> selector) => (await task).Average(selector);

    public static async Task<decimal?> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal?> selector) => (await task).Average(selector);

    public static async Task<double?> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double?> selector) => (await task).Average(selector);

    public static async Task<double?> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int?> selector) => (await task).Average(selector);

    public static async Task<double?> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long?> selector) => (await task).Average(selector);

    public static async Task<float?> Average<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float?> selector) => (await task).Average(selector);

    public static async Task<int> Count<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).Count();

    public static async Task<int> Count<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).Count(predicate);

    public static async Task<long> LongCount<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).LongCount();

    public static async Task<long> LongCount<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).LongCount(predicate);

    public static async Task<double> Max(this Task<IEnumerable<double>> task) => (await task).Max();
    public static async Task<int> Max(this Task<IEnumerable<int>> task) => (await task).Max();
    public static async Task<long> Max(this Task<IEnumerable<long>> task) => (await task).Max();
    public static async Task<float> Max(this Task<IEnumerable<float>> task) => (await task).Max();
    public static async Task<decimal> Max(this Task<IEnumerable<decimal>> task) => (await task).Max();
    public static async Task<decimal?> Max(this Task<IEnumerable<decimal?>> task) => (await task).Max();
    public static async Task<double?> Max(this Task<IEnumerable<double?>> task) => (await task).Max();
    public static async Task<int?> Max(this Task<IEnumerable<int?>> task) => (await task).Max();
    public static async Task<long?> Max(this Task<IEnumerable<long?>> task) => (await task).Max();
    public static async Task<float?> Max(this Task<IEnumerable<float?>> task) => (await task).Max();

    public static async Task<TSource?> Max<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).Max();

    public static async Task<double> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double> selector) => (await task).Max(selector);

    public static async Task<int> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int> selector) => (await task).Max(selector);

    public static async Task<long> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long> selector) => (await task).Max(selector);

    public static async Task<float> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float> selector) => (await task).Max(selector);

    public static async Task<decimal> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal> selector) => (await task).Max(selector);

    public static async Task<decimal?> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal?> selector) => (await task).Max(selector);

    public static async Task<double?> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double?> selector) => (await task).Max(selector);

    public static async Task<int?> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int?> selector) => (await task).Max(selector);

    public static async Task<long?> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long?> selector) => (await task).Max(selector);

    public static async Task<float?> Max<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float?> selector) => (await task).Max(selector);

    public static async Task<TResult?> Max<TSource, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TResult> selector) => (await task).Max(selector);

    public static async Task<double> Min(this Task<IEnumerable<double>> task) => (await task).Min();
    public static async Task<int> Min(this Task<IEnumerable<int>> task) => (await task).Min();
    public static async Task<long> Min(this Task<IEnumerable<long>> task) => (await task).Min();
    public static async Task<float> Min(this Task<IEnumerable<float>> task) => (await task).Min();
    public static async Task<decimal> Min(this Task<IEnumerable<decimal>> task) => (await task).Min();
    public static async Task<decimal?> Min(this Task<IEnumerable<decimal?>> task) => (await task).Min();
    public static async Task<double?> Min(this Task<IEnumerable<double?>> task) => (await task).Min();
    public static async Task<int?> Min(this Task<IEnumerable<int?>> task) => (await task).Min();
    public static async Task<long?> Min(this Task<IEnumerable<long?>> task) => (await task).Min();
    public static async Task<float?> Min(this Task<IEnumerable<float?>> task) => (await task).Min();

    public static async Task<TSource?> Min<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).Min();

    public static async Task<double> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double> selector) => (await task).Min(selector);

    public static async Task<int> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int> selector) => (await task).Min(selector);

    public static async Task<long> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long> selector) => (await task).Min(selector);

    public static async Task<float> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float> selector) => (await task).Min(selector);

    public static async Task<decimal> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal> selector) => (await task).Min(selector);

    public static async Task<decimal?> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal?> selector) => (await task).Min(selector);

    public static async Task<double?> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double?> selector) => (await task).Min(selector);

    public static async Task<int?> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int?> selector) => (await task).Min(selector);

    public static async Task<long?> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long?> selector) => (await task).Min(selector);

    public static async Task<float?> Min<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float?> selector) => (await task).Min(selector);

    public static async Task<TResult?> Min<TSource, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TResult> selector) => (await task).Min(selector);

    public static async Task<double> Sum(this Task<IEnumerable<double>> task) => (await task).Sum();
    public static async Task<int> Sum(this Task<IEnumerable<int>> task) => (await task).Sum();
    public static async Task<long> Sum(this Task<IEnumerable<long>> task) => (await task).Sum();
    public static async Task<float> Sum(this Task<IEnumerable<float>> task) => (await task).Sum();
    public static async Task<decimal> Sum(this Task<IEnumerable<decimal>> task) => (await task).Sum();
    public static async Task<decimal?> Sum(this Task<IEnumerable<decimal?>> task) => (await task).Sum();
    public static async Task<double?> Sum(this Task<IEnumerable<double?>> task) => (await task).Sum();
    public static async Task<int?> Sum(this Task<IEnumerable<int?>> task) => (await task).Sum();
    public static async Task<long?> Sum(this Task<IEnumerable<long?>> task) => (await task).Sum();
    public static async Task<float?> Sum(this Task<IEnumerable<float?>> task) => (await task).Sum();

    public static async Task<double> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double> selector) => (await task).Sum(selector);

    public static async Task<int> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int> selector) => (await task).Sum(selector);

    public static async Task<long> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long> selector) => (await task).Sum(selector);

    public static async Task<float> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float> selector) => (await task).Sum(selector);

    public static async Task<decimal> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal> selector) => (await task).Sum(selector);

    public static async Task<decimal?> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, decimal?> selector) => (await task).Sum(selector);

    public static async Task<double?> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, double?> selector) => (await task).Sum(selector);

    public static async Task<int?> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int?> selector) => (await task).Sum(selector);

    public static async Task<long?> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, long?> selector) => (await task).Sum(selector);

    public static async Task<float?> Sum<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, float?> selector) => (await task).Sum(selector);
}

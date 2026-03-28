using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class PartitioningExtensions
{
    public static async Task<IEnumerable<TSource>> Append<TSource>(
        this Task<IEnumerable<TSource>> task,
        TSource element) => (await task).Append(element);

    public static async Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(
        this Task<IEnumerable<TSource>> task) => (await task).DefaultIfEmpty();

    public static async Task<IEnumerable<TSource>> DefaultIfEmpty<TSource>(
        this Task<IEnumerable<TSource>> task,
        TSource defaultValue) => (await task).DefaultIfEmpty(defaultValue);

    public static async Task<IEnumerable<TSource>> Prepend<TSource>(
        this Task<IEnumerable<TSource>> task,
        TSource element) => (await task).Prepend(element);

    public static async Task<IEnumerable<TSource>> Skip<TSource>(
        this Task<IEnumerable<TSource>> task,
        int count) => (await task).Skip(count);

    public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).SkipWhile(predicate);

    public static async Task<IEnumerable<TSource>> SkipWhile<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int, bool> predicate) => (await task).SkipWhile(predicate);

    public static async Task<IEnumerable<TSource>> Take<TSource>(
        this Task<IEnumerable<TSource>> task,
        int count) => (await task).Take(count);

    public static async Task<IEnumerable<TSource>> TakeWhile<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).TakeWhile(predicate);

    public static async Task<IEnumerable<TSource>> TakeWhile<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int, bool> predicate) => (await task).TakeWhile(predicate);
}

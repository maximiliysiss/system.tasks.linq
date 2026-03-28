using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class ProjectionExtensions
{
    public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, TResult> selector) => (await task).Select(selector);

    public static async Task<IEnumerable<TResult>> Select<TSource, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int, TResult> selector) => (await task).Select(selector);

    public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, IEnumerable<TResult>> selector) => (await task).SelectMany(selector);

    public static async Task<IEnumerable<TResult>> SelectMany<TSource, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int, IEnumerable<TResult>> selector) => (await task).SelectMany(selector);

    public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, IEnumerable<TCollection>> collectionSelector,
        Func<TSource, TCollection, TResult> resultSelector) =>
        (await task).SelectMany(collectionSelector, resultSelector);

    public static async Task<IEnumerable<TResult>> SelectMany<TSource, TCollection, TResult>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, int, IEnumerable<TCollection>> collectionSelector,
        Func<TSource, TCollection, TResult> resultSelector) =>
        (await task).SelectMany(collectionSelector, resultSelector);
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class ElementExtensions
{
    public static async Task<TSource> ElementAt<TSource>(this Task<IEnumerable<TSource>> task, int index) =>
        (await task).ElementAt(index);

    public static async Task<TSource?> ElementAtOrDefault<TSource>(this Task<IEnumerable<TSource>> task, int index) =>
        (await task).ElementAtOrDefault(index);

    public static async Task<TSource> First<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).First();

    public static async Task<TSource> First<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).First(predicate);

    public static async Task<TSource?> FirstOrDefault<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).FirstOrDefault();

    public static async Task<TSource?> FirstOrDefault<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).FirstOrDefault(predicate);

    public static async Task<TSource> Last<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).Last();

    public static async Task<TSource> Last<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).Last(predicate);

    public static async Task<TSource?> LastOrDefault<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).LastOrDefault();

    public static async Task<TSource?> LastOrDefault<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).LastOrDefault(predicate);

    public static async Task<TSource> Single<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).Single();

    public static async Task<TSource> Single<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).Single(predicate);

    public static async Task<TSource?> SingleOrDefault<TSource>(this Task<IEnumerable<TSource>> task) =>
        (await task).SingleOrDefault();

    public static async Task<TSource?> SingleOrDefault<TSource>(
        this Task<IEnumerable<TSource>> task,
        Func<TSource, bool> predicate) => (await task).SingleOrDefault(predicate);
}

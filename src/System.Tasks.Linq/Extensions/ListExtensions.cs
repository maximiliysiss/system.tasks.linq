using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

/// <summary>
/// Provides <c>AsEnumerable</c> for <c>Task&lt;List&lt;T&gt;&gt;</c>, widening it to
/// <c>Task&lt;IEnumerable&lt;T&gt;&gt;</c> so that all LINQ extension methods become available.
/// </summary>
public static class ListExtensions
{
    /// <summary>
    /// Awaits the task and returns the resulting <see cref="List{TSource}"/> as an <see cref="IEnumerable{TSource}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source list.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the source list typed as <see cref="IEnumerable{TSource}"/>.</returns>
    public static async Task<IEnumerable<TSource>> AsEnumerable<TSource>(this Task<List<TSource>> task) =>
        await task.ConfigureAwait(false);
}

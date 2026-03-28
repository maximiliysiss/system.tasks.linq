using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

/// <summary>
/// Provides <c>AsEnumerable</c> for <c>Task&lt;IReadOnlyCollection&lt;T&gt;&gt;</c>, widening it to
/// <c>Task&lt;IEnumerable&lt;T&gt;&gt;</c> so that all LINQ extension methods become available.
/// </summary>
public static class ReadOnlyCollectionExtensions
{
    /// <summary>
    /// Awaits the task and returns the resulting <see cref="IReadOnlyCollection{TSource}"/> as an <see cref="IEnumerable{TSource}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source collection.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the source collection typed as <see cref="IEnumerable{TSource}"/>.</returns>
    public static async Task<IEnumerable<TSource>> AsEnumerable<TSource>(this Task<IReadOnlyCollection<TSource>> task) =>
        await task.ConfigureAwait(false);
}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

/// <summary>
/// Provides <c>AsEnumerable</c> for <c>Task&lt;T[]&gt;</c>, widening it to
/// <c>Task&lt;IEnumerable&lt;T&gt;&gt;</c> so that all LINQ extension methods become available.
/// </summary>
public static class ArrayExtensions
{
    /// <summary>
    /// Awaits the task and returns the resulting array as an <see cref="IEnumerable{TSource}"/>.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements in the source array.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <returns>A task that represents the source array typed as <see cref="IEnumerable{TSource}"/>.</returns>
    public static async Task<IEnumerable<TSource>> AsEnumerable<TSource>(this Task<TSource[]> task) =>
        await task;
}

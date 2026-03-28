using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class ZipExtensions
{
    /// <summary>
    /// Awaits the task and merges each element of the resulting sequence with the corresponding element
    /// of a second sequence using the specified result selector function.
    /// </summary>
    /// <typeparam name="TFirst">The type of the elements in the first sequence.</typeparam>
    /// <typeparam name="TSecond">The type of the elements in the second sequence.</typeparam>
    /// <typeparam name="TResult">The type of the elements returned by <paramref name="resultSelector"/>.</typeparam>
    /// <param name="task">A task whose result is the source sequence.</param>
    /// <param name="second">The second sequence to merge with.</param>
    /// <param name="resultSelector">A function that specifies how to merge the elements from the two sequences.</param>
    /// <returns>A task that represents a sequence of merged elements produced by applying the result selector pairwise.</returns>
    public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
        this Task<IEnumerable<TFirst>> task,
        IEnumerable<TSecond> second,
        Func<TFirst, TSecond, TResult> resultSelector) =>
        (await task).Zip(second, resultSelector);
}

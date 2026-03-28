using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Tasks.Linq.Extensions;

public static class ZipExtensions
{
    public static async Task<IEnumerable<TResult>> Zip<TFirst, TSecond, TResult>(
        this Task<IEnumerable<TFirst>> task,
        IEnumerable<TSecond> second,
        Func<TFirst, TSecond, TResult> resultSelector) =>
        (await task).Zip(second, resultSelector);
}

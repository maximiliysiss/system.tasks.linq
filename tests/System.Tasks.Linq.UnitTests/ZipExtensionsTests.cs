using System.Tasks.Linq.Extensions;
using FluentAssertions;
using Xunit;

namespace System.Tasks.Linq.UnitTests;

public class ZipExtensionsTests
{
    private static Task<IEnumerable<T>> T<T>(IEnumerable<T> source) =>
        Task.FromResult(source);

    [Fact]
    public async Task Zip_PairsCorrespondingElements()
    {
        var result = await T([1, 2, 3]).Zip(["a", "b", "c"], (n, s) => $"{n}{s}");
        result.Should().Equal("1a", "2b", "3c");
    }

    [Fact]
    public async Task Zip_FirstShorter_StopsAtFirstLength()
    {
        var result = await T([1, 2]).Zip(["a", "b", "c"], (n, s) => $"{n}{s}");
        result.Should().Equal("1a", "2b");
    }

    [Fact]
    public async Task Zip_SecondShorter_StopsAtSecondLength()
    {
        var result = await T([1, 2, 3]).Zip(["a"], (n, s) => $"{n}{s}");
        result.Should().Equal("1a");
    }

    [Fact]
    public async Task Zip_EmptyFirst_ReturnsEmpty()
    {
        var result = await T(Array.Empty<int>()).Zip(["a", "b"], (n, s) => $"{n}{s}");
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Zip_EmptySecond_ReturnsEmpty()
    {
        var result = await T([1, 2]).Zip(Array.Empty<string>(), (n, s) => $"{n}{s}");
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Zip_ResultSelectorApplied()
    {
        var result = await T([1, 2, 3]).Zip([10, 20, 30], (a, b) => a + b);
        result.Should().Equal(11, 22, 33);
    }
}

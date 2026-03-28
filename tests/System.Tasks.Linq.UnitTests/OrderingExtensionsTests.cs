using System.Tasks.Linq.Extensions;
using FluentAssertions;
using Xunit;

namespace System.Tasks.Linq.UnitTests;

public class OrderingExtensionsTests
{
    private static Task<IEnumerable<T>> T<T>(IEnumerable<T> source) =>
        Task.FromResult(source);

    // OrderBy

    [Fact]
    public async Task OrderBy_SortsAscending()
    {
        var result = await T([3, 1, 4, 1, 5]).OrderBy(x => x);
        result.Should().BeInAscendingOrder();
    }

    [Fact]
    public async Task OrderBy_SortsBySelector()
    {
        var result = await T(["banana", "apple", "cherry"]).OrderBy(s => s.Length);
        result.Select(s => s.Length).Should().BeInAscendingOrder();
    }

    [Fact]
    public async Task OrderBy_EmptySequence_ReturnsEmpty()
    {
        var result = await T(Array.Empty<int>()).OrderBy(x => x);
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task OrderBy_WithComparer_UsesComparer()
    {
        var source = new[] { "Banana", "apple", "Cherry" };
        var result = (await T(source).OrderBy(s => s, StringComparer.OrdinalIgnoreCase)).ToList();
        result.Should().Equal("apple", "Banana", "Cherry");
    }

    [Fact]
    public async Task OrderBy_ReturnsIOrderedEnumerable_SupportsThenBy()
    {
        var ordered = await T([3, 1, 2]).OrderBy(x => x);
        var thenBy = ordered.ThenByDescending(x => x);
        thenBy.Should().BeInAscendingOrder();
    }

    // OrderByDescending

    [Fact]
    public async Task OrderByDescending_SortsDescending()
    {
        var result = await T([3, 1, 4, 1, 5]).OrderByDescending(x => x);
        result.Should().BeInDescendingOrder();
    }

    [Fact]
    public async Task OrderByDescending_SortsBySelector()
    {
        var result = await T(["a", "ccc", "bb"]).OrderByDescending(s => s.Length);
        result.Select(s => s.Length).Should().BeInDescendingOrder();
    }

    [Fact]
    public async Task OrderByDescending_EmptySequence_ReturnsEmpty()
    {
        var result = await T(Array.Empty<int>()).OrderByDescending(x => x);
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task OrderByDescending_WithComparer_UsesComparer()
    {
        var source = new[] { "apple", "Banana", "Cherry" };
        var result = (await T(source).OrderByDescending(s => s, StringComparer.OrdinalIgnoreCase)).ToList();
        result.Should().Equal("Cherry", "Banana", "apple");
    }

    // Reverse

    [Fact]
    public async Task Reverse_ReversesSequence()
    {
        var result = await T([1, 2, 3]).Reverse();
        result.Should().Equal(3, 2, 1);
    }

    [Fact]
    public async Task Reverse_SingleElement_ReturnsSingleElement()
    {
        var result = await T([42]).Reverse();
        result.Should().Equal(42);
    }

    [Fact]
    public async Task Reverse_EmptySequence_ReturnsEmpty()
    {
        var result = await T(Array.Empty<int>()).Reverse();
        result.Should().BeEmpty();
    }
}

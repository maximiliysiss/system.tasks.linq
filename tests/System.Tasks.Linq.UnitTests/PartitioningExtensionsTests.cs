using System.Tasks.Linq.Extensions;
using FluentAssertions;
using Xunit;

namespace System.Tasks.Linq.UnitTests;

public class PartitioningExtensionsTests
{
    private static Task<IEnumerable<T>> T<T>(IEnumerable<T> source) =>
        Task.FromResult(source);

    // Append

    [Fact]
    public async Task Append_AddsElementAtEnd()
    {
        var result = await T([1, 2, 3]).Append(4);
        result.Should().Equal(1, 2, 3, 4);
    }

    [Fact]
    public async Task Append_EmptySequence_ReturnsSingleElement()
    {
        var result = await T(Array.Empty<int>()).Append(42);
        result.Should().Equal(42);
    }

    // DefaultIfEmpty (no default)

    [Fact]
    public async Task DefaultIfEmpty_NonEmpty_ReturnsSameSequence()
    {
        var result = await T([1, 2, 3]).DefaultIfEmpty();
        result.Should().Equal(1, 2, 3);
    }

    [Fact]
    public async Task DefaultIfEmpty_Empty_ReturnsSingleDefault()
    {
        var result = await T(Array.Empty<int>()).DefaultIfEmpty();
        result.Should().Equal(0);
    }

    // DefaultIfEmpty (with custom default)

    [Fact]
    public async Task DefaultIfEmpty_WithDefault_NonEmpty_ReturnsSameSequence()
    {
        var result = await T([1, 2]).DefaultIfEmpty(99);
        result.Should().Equal(1, 2);
    }

    [Fact]
    public async Task DefaultIfEmpty_WithDefault_Empty_ReturnsCustomDefault()
    {
        var result = await T(Array.Empty<int>()).DefaultIfEmpty(99);
        result.Should().Equal(99);
    }

    // Prepend

    [Fact]
    public async Task Prepend_AddsElementAtStart()
    {
        var result = await T([2, 3, 4]).Prepend(1);
        result.Should().Equal(1, 2, 3, 4);
    }

    [Fact]
    public async Task Prepend_EmptySequence_ReturnsSingleElement()
    {
        var result = await T(Array.Empty<int>()).Prepend(42);
        result.Should().Equal(42);
    }

    // Skip

    [Fact]
    public async Task Skip_SkipsFirstNElements()
    {
        var result = await T([1, 2, 3, 4, 5]).Skip(2);
        result.Should().Equal(3, 4, 5);
    }

    [Fact]
    public async Task Skip_ZeroCount_ReturnsFull()
    {
        var result = await T([1, 2, 3]).Skip(0);
        result.Should().Equal(1, 2, 3);
    }

    [Fact]
    public async Task Skip_MoreThanLength_ReturnsEmpty()
    {
        var result = await T([1, 2, 3]).Skip(10);
        result.Should().BeEmpty();
    }

    // SkipWhile (predicate)

    [Fact]
    public async Task SkipWhile_SkipsWhilePredicateTrue()
    {
        var result = await T([1, 2, 3, 4, 1]).SkipWhile(x => x < 3);
        result.Should().Equal(3, 4, 1);
    }

    [Fact]
    public async Task SkipWhile_AllMatch_ReturnsEmpty()
    {
        var result = await T([1, 2, 3]).SkipWhile(x => x > 0);
        result.Should().BeEmpty();
    }

    // SkipWhile (predicate with index)

    [Fact]
    public async Task SkipWhile_WithIndex_SkipsUsingIndex()
    {
        var result = await T([10, 20, 30, 40]).SkipWhile((x, i) => i < 2);
        result.Should().Equal(30, 40);
    }

    // Take

    [Fact]
    public async Task Take_ReturnsFirstNElements()
    {
        var result = await T([1, 2, 3, 4, 5]).Take(3);
        result.Should().Equal(1, 2, 3);
    }

    [Fact]
    public async Task Take_ZeroCount_ReturnsEmpty()
    {
        var result = await T([1, 2, 3]).Take(0);
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Take_MoreThanLength_ReturnsAll()
    {
        var result = await T([1, 2, 3]).Take(10);
        result.Should().Equal(1, 2, 3);
    }

    // TakeWhile (predicate)

    [Fact]
    public async Task TakeWhile_TakesWhilePredicateTrue()
    {
        var result = await T([1, 2, 3, 4, 1]).TakeWhile(x => x < 4);
        result.Should().Equal(1, 2, 3);
    }

    [Fact]
    public async Task TakeWhile_FirstFails_ReturnsEmpty()
    {
        var result = await T([5, 1, 2]).TakeWhile(x => x < 3);
        result.Should().BeEmpty();
    }

    // TakeWhile (predicate with index)

    [Fact]
    public async Task TakeWhile_WithIndex_TakesUsingIndex()
    {
        var result = await T([10, 20, 30, 40]).TakeWhile((x, i) => i < 2);
        result.Should().Equal(10, 20);
    }
}

using System.Tasks.Linq.Extensions;
using FluentAssertions;
using Xunit;

namespace System.Tasks.Linq.UnitTests;

public class ProjectionExtensionsTests
{
    private static Task<IEnumerable<T>> T<T>(IEnumerable<T> source) =>
        Task.FromResult(source);

    // Select (selector)

    [Fact]
    public async Task Select_ProjectsElements()
    {
        var result = await T([1, 2, 3]).Select(x => x * 2);
        result.Should().Equal(2, 4, 6);
    }

    [Fact]
    public async Task Select_EmptySequence_ReturnsEmpty()
    {
        var result = await T(Array.Empty<int>()).Select(x => x.ToString());
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Select_ToStringProjection_Works()
    {
        var result = await T([1, 2, 3]).Select(x => x.ToString());
        result.Should().Equal("1", "2", "3");
    }

    // Select (selector with index)

    [Fact]
    public async Task Select_WithIndex_IndexStartsAtZero()
    {
        var result = await T(["a", "b", "c"]).Select((s, i) => $"{i}:{s}");
        result.Should().Equal("0:a", "1:b", "2:c");
    }

    [Fact]
    public async Task Select_WithIndex_EmptySequence_ReturnsEmpty()
    {
        var result = await T(Array.Empty<string>()).Select((s, i) => i);
        result.Should().BeEmpty();
    }

    // SelectMany (selector)

    [Fact]
    public async Task SelectMany_FlattensNestedSequences()
    {
        var source = new[] { new[] { 1, 2 }, new[] { 3, 4 }, new[] { 5 } };
        var result = await T(source).SelectMany(a => a);
        result.Should().Equal(1, 2, 3, 4, 5);
    }

    [Fact]
    public async Task SelectMany_EmptySource_ReturnsEmpty()
    {
        var result = await T(Array.Empty<int[]>()).SelectMany(a => a);
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task SelectMany_EmptyInnerSequences_ReturnsEmpty()
    {
        var source = new[] { Array.Empty<int>(), Array.Empty<int>() };
        var result = await T(source).SelectMany(a => a);
        result.Should().BeEmpty();
    }

    // SelectMany (selector with index)

    [Fact]
    public async Task SelectMany_WithIndex_IndexPassedToSelector()
    {
        var source = new[] { "ab", "cd" };
        var result = await T(source).SelectMany((s, i) => s.Select(c => $"{i}:{c}"));
        result.Should().Equal("0:a", "0:b", "1:c", "1:d");
    }

    // SelectMany (collection + result selector)

    [Fact]
    public async Task SelectMany_WithCollectionAndResultSelector_ProjectsCombined()
    {
        var source = new[] { "ab", "cd" };
        var result = await T(source).SelectMany(
            s => s.ToCharArray(),
            (s, c) => $"{s[0]}-{c}");
        result.Should().Equal("a-a", "a-b", "c-c", "c-d");
    }

    // SelectMany (collection with index + result selector)

    [Fact]
    public async Task SelectMany_WithIndexedCollectionAndResultSelector_ProjectsCombined()
    {
        var source = new[] { "ab", "cd" };
        var result = await T(source).SelectMany(
            (s, i) => s.Select(c => (i, c)),
            (s, t) => $"{t.i}:{t.c}");
        result.Should().Equal("0:a", "0:b", "1:c", "1:d");
    }
}

using System.Tasks.Linq.Extensions;
using FluentAssertions;
using Xunit;

namespace System.Tasks.Linq.UnitTests;

public class SetExtensionsTests
{
    private static Task<IEnumerable<T>> T<T>(IEnumerable<T> source) =>
        Task.FromResult(source);

    // Concat

    [Fact]
    public async Task Concat_AppendSecondSequence()
    {
        var result = await T([1, 2]).Concat([3, 4]);
        result.Should().Equal(1, 2, 3, 4);
    }

    [Fact]
    public async Task Concat_FirstEmpty_ReturnsSecond()
    {
        var result = await T(Array.Empty<int>()).Concat([1, 2]);
        result.Should().Equal(1, 2);
    }

    [Fact]
    public async Task Concat_SecondEmpty_ReturnsFirst()
    {
        var result = await T([1, 2]).Concat([]);
        result.Should().Equal(1, 2);
    }

    [Fact]
    public async Task Concat_BothEmpty_ReturnsEmpty()
    {
        var result = await T(Array.Empty<int>()).Concat([]);
        result.Should().BeEmpty();
    }

    // Distinct

    [Fact]
    public async Task Distinct_RemovesDuplicates()
    {
        var result = await T([1, 2, 2, 3, 1]).Distinct();
        result.Should().Equal(1, 2, 3);
    }

    [Fact]
    public async Task Distinct_AllUnique_ReturnsAll()
    {
        var result = await T([1, 2, 3]).Distinct();
        result.Should().Equal(1, 2, 3);
    }

    [Fact]
    public async Task Distinct_EmptySequence_ReturnsEmpty()
    {
        var result = await T(Array.Empty<int>()).Distinct();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Distinct_WithComparer_UsesComparer()
    {
        var result = await T(["Apple", "apple", "Banana"])
            .Distinct(StringComparer.OrdinalIgnoreCase);
        result.Should().HaveCount(2);
    }

    // Except

    [Fact]
    public async Task Except_RemovesElementsFromSecond()
    {
        var result = await T([1, 2, 3, 4]).Except([2, 4]);
        result.Should().Equal(1, 3);
    }

    [Fact]
    public async Task Except_NoOverlap_ReturnsFirstDistinct()
    {
        var result = await T([1, 2, 2]).Except([3]);
        result.Should().Equal(1, 2);
    }

    [Fact]
    public async Task Except_AllExcluded_ReturnsEmpty()
    {
        var result = await T([1, 2]).Except([1, 2]);
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Except_WithComparer_UsesComparer()
    {
        var result = await T(["Apple", "Banana"])
            .Except(["apple"], StringComparer.OrdinalIgnoreCase);
        result.Should().Equal("Banana");
    }

    // Intersect

    [Fact]
    public async Task Intersect_ReturnsCommonElements()
    {
        var result = await T([1, 2, 3, 4]).Intersect([2, 4, 6]);
        result.Should().Equal(2, 4);
    }

    [Fact]
    public async Task Intersect_NoOverlap_ReturnsEmpty()
    {
        var result = await T([1, 2]).Intersect([3, 4]);
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Intersect_DuplicatesInFirst_ReturnsDistinct()
    {
        var result = await T([1, 1, 2]).Intersect([1]);
        result.Should().Equal(1);
    }

    [Fact]
    public async Task Intersect_WithComparer_UsesComparer()
    {
        var result = await T(["Apple", "Banana"])
            .Intersect(["apple"], StringComparer.OrdinalIgnoreCase);
        result.Should().Equal("Apple");
    }

    // Union

    [Fact]
    public async Task Union_CombinesWithoutDuplicates()
    {
        var result = await T([1, 2, 3]).Union([2, 3, 4]);
        result.Should().Equal(1, 2, 3, 4);
    }

    [Fact]
    public async Task Union_NoOverlap_CombinesAll()
    {
        var result = await T([1, 2]).Union([3, 4]);
        result.Should().Equal(1, 2, 3, 4);
    }

    [Fact]
    public async Task Union_BothEmpty_ReturnsEmpty()
    {
        var result = await T(Array.Empty<int>()).Union([]);
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Union_WithComparer_UsesComparer()
    {
        var result = await T(["Apple"])
            .Union(["apple", "Banana"], StringComparer.OrdinalIgnoreCase);
        result.Should().HaveCount(2);
    }
}

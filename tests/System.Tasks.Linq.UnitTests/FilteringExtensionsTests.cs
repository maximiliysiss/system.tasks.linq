using System.Tasks.Linq.Extensions;
using FluentAssertions;
using Xunit;

namespace System.Tasks.Linq.UnitTests;

public class FilteringExtensionsTests
{
    private static Task<IEnumerable<T>> T<T>(IEnumerable<T> source) =>
        Task.FromResult(source);

    // All

    [Fact]
    public async Task All_AllMatch_ReturnsTrue()
    {
        var result = await T([2, 4, 6]).All(x => x % 2 == 0);
        result.Should().BeTrue();
    }

    [Fact]
    public async Task All_SomeDoNotMatch_ReturnsFalse()
    {
        var result = await T([2, 3, 6]).All(x => x % 2 == 0);
        result.Should().BeFalse();
    }

    [Fact]
    public async Task All_EmptySequence_ReturnsTrue()
    {
        var result = await T(Array.Empty<int>()).All(x => x > 0);
        result.Should().BeTrue();
    }

    // Any (no predicate)

    [Fact]
    public async Task Any_NonEmpty_ReturnsTrue()
    {
        var result = await T([1]).Any();
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Any_Empty_ReturnsFalse()
    {
        var result = await T(Array.Empty<int>()).Any();
        result.Should().BeFalse();
    }

    // Any (with predicate)

    [Fact]
    public async Task Any_WithPredicate_HasMatch_ReturnsTrue()
    {
        var result = await T([1, 2, 3]).Any(x => x == 2);
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Any_WithPredicate_NoMatch_ReturnsFalse()
    {
        var result = await T([1, 3, 5]).Any(x => x % 2 == 0);
        result.Should().BeFalse();
    }

    // Contains

    [Fact]
    public async Task Contains_ElementPresent_ReturnsTrue()
    {
        var result = await T([1, 2, 3]).Contains(2);
        result.Should().BeTrue();
    }

    [Fact]
    public async Task Contains_ElementAbsent_ReturnsFalse()
    {
        var result = await T([1, 2, 3]).Contains(5);
        result.Should().BeFalse();
    }

    [Fact]
    public async Task Contains_WithComparer_UsesComparer()
    {
        var result = await T(["Apple", "Banana"])
            .Contains("apple", StringComparer.OrdinalIgnoreCase);
        result.Should().BeTrue();
    }

    // SequenceEqual

    [Fact]
    public async Task SequenceEqual_SameElements_ReturnsTrue()
    {
        var result = await T([1, 2, 3]).SequenceEqual([1, 2, 3]);
        result.Should().BeTrue();
    }

    [Fact]
    public async Task SequenceEqual_DifferentElements_ReturnsFalse()
    {
        var result = await T([1, 2, 3]).SequenceEqual([1, 2, 4]);
        result.Should().BeFalse();
    }

    [Fact]
    public async Task SequenceEqual_DifferentLengths_ReturnsFalse()
    {
        var result = await T([1, 2]).SequenceEqual([1, 2, 3]);
        result.Should().BeFalse();
    }

    [Fact]
    public async Task SequenceEqual_WithComparer_UsesComparer()
    {
        var result = await T(["A", "B"])
            .SequenceEqual(["a", "b"], StringComparer.OrdinalIgnoreCase);
        result.Should().BeTrue();
    }

    // Where (predicate)

    [Fact]
    public async Task Where_FiltersByPredicate()
    {
        var result = await T([1, 2, 3, 4, 5]).Where(x => x % 2 == 0);
        result.Should().Equal(2, 4);
    }

    [Fact]
    public async Task Where_NoMatches_ReturnsEmpty()
    {
        var result = await T([1, 3, 5]).Where(x => x % 2 == 0);
        result.Should().BeEmpty();
    }

    // Where (predicate with index)

    [Fact]
    public async Task Where_WithIndex_FiltersByPredicateAndIndex()
    {
        var result = await T([10, 20, 30, 40]).Where((x, i) => i % 2 == 0);
        result.Should().Equal(10, 30);
    }

    [Fact]
    public async Task Where_WithIndex_IndexStartsAtZero()
    {
        var captured = new List<int>();
        (await T(["a", "b", "c"]).Where((_, i) => { captured.Add(i); return true; })).ToList();
        captured.Should().Equal(0, 1, 2);
    }
}

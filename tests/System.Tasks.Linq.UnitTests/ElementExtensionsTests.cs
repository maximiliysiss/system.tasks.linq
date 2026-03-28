using System.Tasks.Linq.Extensions;
using FluentAssertions;
using Xunit;

namespace System.Tasks.Linq.UnitTests;

public class ElementExtensionsTests
{
    private static Task<IEnumerable<T>> T<T>(IEnumerable<T> source) =>
        Task.FromResult(source);

    // ElementAt

    [Fact]
    public async Task ElementAt_ValidIndex_ReturnsElement()
    {
        var result = await T([10, 20, 30]).ElementAt(1);
        result.Should().Be(20);
    }

    [Fact]
    public async Task ElementAt_OutOfRange_Throws()
    {
        var act = async () => await T([1, 2]).ElementAt(5);
        await act.Should().ThrowAsync<IndexOutOfRangeException>();
    }

    // ElementAtOrDefault

    [Fact]
    public async Task ElementAtOrDefault_ValidIndex_ReturnsElement()
    {
        var result = await T([10, 20, 30]).ElementAtOrDefault(2);
        result.Should().Be(30);
    }

    [Fact]
    public async Task ElementAtOrDefault_OutOfRange_ReturnsDefault()
    {
        var result = await T([1, 2]).ElementAtOrDefault(10);
        result.Should().Be(0);
    }

    // First

    [Fact]
    public async Task First_NonEmpty_ReturnsFirstElement()
    {
        var result = await T([5, 10, 15]).First();
        result.Should().Be(5);
    }

    [Fact]
    public async Task First_EmptySequence_Throws()
    {
        var act = async () => await T(Array.Empty<int>()).First();
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    [Fact]
    public async Task First_WithPredicate_ReturnsFirstMatch()
    {
        var result = await T([1, 2, 3, 4]).First(x => x % 2 == 0);
        result.Should().Be(2);
    }

    [Fact]
    public async Task First_WithPredicate_NoMatch_Throws()
    {
        var act = async () => await T([1, 3, 5]).First(x => x % 2 == 0);
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    // FirstOrDefault

    [Fact]
    public async Task FirstOrDefault_NonEmpty_ReturnsFirstElement()
    {
        var result = await T([5, 10, 15]).FirstOrDefault();
        result.Should().Be(5);
    }

    [Fact]
    public async Task FirstOrDefault_EmptySequence_ReturnsDefault()
    {
        var result = await T(Array.Empty<int>()).FirstOrDefault();
        result.Should().Be(0);
    }

    [Fact]
    public async Task FirstOrDefault_WithPredicate_ReturnsFirstMatch()
    {
        var result = await T([1, 2, 3]).FirstOrDefault(x => x > 1);
        result.Should().Be(2);
    }

    [Fact]
    public async Task FirstOrDefault_WithPredicate_NoMatch_ReturnsDefault()
    {
        var result = await T([1, 3, 5]).FirstOrDefault(x => x % 2 == 0);
        result.Should().Be(0);
    }

    // Last

    [Fact]
    public async Task Last_NonEmpty_ReturnsLastElement()
    {
        var result = await T([5, 10, 15]).Last();
        result.Should().Be(15);
    }

    [Fact]
    public async Task Last_EmptySequence_Throws()
    {
        var act = async () => await T(Array.Empty<int>()).Last();
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    [Fact]
    public async Task Last_WithPredicate_ReturnsLastMatch()
    {
        var result = await T([1, 2, 3, 4]).Last(x => x % 2 == 0);
        result.Should().Be(4);
    }

    [Fact]
    public async Task Last_WithPredicate_NoMatch_Throws()
    {
        var act = async () => await T([1, 3, 5]).Last(x => x % 2 == 0);
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    // LastOrDefault

    [Fact]
    public async Task LastOrDefault_NonEmpty_ReturnsLastElement()
    {
        var result = await T([5, 10, 15]).LastOrDefault();
        result.Should().Be(15);
    }

    [Fact]
    public async Task LastOrDefault_EmptySequence_ReturnsDefault()
    {
        var result = await T(Array.Empty<string>()).LastOrDefault();
        result.Should().BeNull();
    }

    [Fact]
    public async Task LastOrDefault_WithPredicate_ReturnsLastMatch()
    {
        var result = await T([1, 2, 3, 4]).LastOrDefault(x => x % 2 == 0);
        result.Should().Be(4);
    }

    [Fact]
    public async Task LastOrDefault_WithPredicate_NoMatch_ReturnsDefault()
    {
        var result = await T([1, 3, 5]).LastOrDefault(x => x % 2 == 0);
        result.Should().Be(0);
    }

    // Single

    [Fact]
    public async Task Single_OneElement_ReturnsElement()
    {
        var result = await T([42]).Single();
        result.Should().Be(42);
    }

    [Fact]
    public async Task Single_EmptySequence_Throws()
    {
        var act = async () => await T(Array.Empty<int>()).Single();
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    [Fact]
    public async Task Single_MultipleElements_Throws()
    {
        var act = async () => await T([1, 2]).Single();
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    [Fact]
    public async Task Single_WithPredicate_OneMatch_ReturnsElement()
    {
        var result = await T([1, 2, 3]).Single(x => x == 2);
        result.Should().Be(2);
    }

    [Fact]
    public async Task Single_WithPredicate_MultipleMatches_Throws()
    {
        var act = async () => await T([2, 4, 6]).Single(x => x % 2 == 0);
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    [Fact]
    public async Task Single_WithPredicate_NoMatch_Throws()
    {
        var act = async () => await T([1, 3]).Single(x => x % 2 == 0);
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    // SingleOrDefault

    [Fact]
    public async Task SingleOrDefault_OneElement_ReturnsElement()
    {
        var result = await T([42]).SingleOrDefault();
        result.Should().Be(42);
    }

    [Fact]
    public async Task SingleOrDefault_EmptySequence_ReturnsDefault()
    {
        var result = await T(Array.Empty<int>()).SingleOrDefault();
        result.Should().Be(0);
    }

    [Fact]
    public async Task SingleOrDefault_MultipleElements_Throws()
    {
        var act = async () => await T([1, 2]).SingleOrDefault();
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    [Fact]
    public async Task SingleOrDefault_WithPredicate_OneMatch_ReturnsElement()
    {
        var result = await T([1, 2, 3]).SingleOrDefault(x => x == 2);
        result.Should().Be(2);
    }

    [Fact]
    public async Task SingleOrDefault_WithPredicate_NoMatch_ReturnsDefault()
    {
        var result = await T([1, 3]).SingleOrDefault(x => x % 2 == 0);
        result.Should().Be(0);
    }
}

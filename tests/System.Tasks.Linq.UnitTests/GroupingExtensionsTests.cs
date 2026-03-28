using System.Tasks.Linq.Extensions;
using FluentAssertions;
using Xunit;

namespace System.Tasks.Linq.UnitTests;

public class GroupingExtensionsTests
{
    private static Task<IEnumerable<T>> T<T>(IEnumerable<T> source) =>
        Task.FromResult(source);

    // GroupBy (key only)

    [Fact]
    public async Task GroupBy_KeySelector_GroupsElementsByKey()
    {
        var source = new[] { 1, 2, 3, 4 };
        var groups = (await T(source).GroupBy(x => x % 2 == 0 ? "even" : "odd")).ToList();

        groups.Should().HaveCount(2);
        groups.Single(g => g.Key == "odd").Should().Equal(1, 3);
        groups.Single(g => g.Key == "even").Should().Equal(2, 4);
    }

    [Fact]
    public async Task GroupBy_KeySelector_EmptySequence_ReturnsEmpty()
    {
        var result = await T(Array.Empty<int>()).GroupBy(x => x);
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GroupBy_KeySelector_WithComparer_UsesComparer()
    {
        var source = new[] { "Apple", "apple", "Banana" };
        var groups = (await T(source).GroupBy(s => s, StringComparer.OrdinalIgnoreCase)).ToList();
        groups.Should().HaveCount(2);
        groups.Single(g => g.Key == "Apple").Should().HaveCount(2);
    }

    // GroupBy (key + element)

    [Fact]
    public async Task GroupBy_KeyAndElementSelector_ProjectsElements()
    {
        var source = new[] { "apple", "avocado", "banana" };
        var groups = (await T(source).GroupBy(s => s[0], s => s.ToUpper())).ToList();

        groups.Single(g => g.Key == 'a').Should().Equal("APPLE", "AVOCADO");
        groups.Single(g => g.Key == 'b').Should().Equal("BANANA");
    }

    // GroupBy (key + result selector)

    [Fact]
    public async Task GroupBy_KeyAndResultSelector_TransformsGroups()
    {
        var source = new[] { 1, 2, 3, 4 };
        var result = (await T(source).GroupBy(
            x => x % 2 == 0,
            (isEven, elements) => $"{(isEven ? "even" : "odd")}:{elements.Sum()}")).ToList();

        result.Should().Contain("odd:4");
        result.Should().Contain("even:6");
    }

    // GroupBy (key + element + result)

    [Fact]
    public async Task GroupBy_KeyElementAndResultSelector_TransformsGroupsAndElements()
    {
        var source = new[] { "apple", "avocado", "banana" };
        var result = (await T(source).GroupBy(
            s => s[0],
            s => s.Length,
            (key, lengths) => $"{key}:{string.Join(",", lengths)}")).ToList();

        result.Should().Contain(r => r.StartsWith("a:"));
        result.Should().Contain(r => r.StartsWith("b:"));
    }

    // GroupJoin

    [Fact]
    public async Task GroupJoin_JoinsOuterWithMatchingInner()
    {
        var outer = new[] { 1, 2, 3 };
        var inner = new[] { (Key: 1, Val: "a"), (Key: 1, Val: "b"), (Key: 2, Val: "c") };

        var result = (await T(outer).GroupJoin(
            inner,
            o => o,
            i => i.Key,
            (o, inners) => $"{o}:{string.Join(",", inners.Select(i => i.Val))}")).ToList();

        result.Should().Contain("1:a,b");
        result.Should().Contain("2:c");
        result.Should().Contain("3:");
    }

    [Fact]
    public async Task GroupJoin_WithComparer_UsesComparer()
    {
        var outer = new[] { "A" };
        var inner = new[] { "a" };

        var result = (await T(outer).GroupJoin(
            inner,
            o => o,
            i => i,
            (o, inners) => inners.Count(),
            StringComparer.OrdinalIgnoreCase)).ToList();

        result.Single().Should().Be(1);
    }

    // Join

    [Fact]
    public async Task Join_ProducesInnerJoin()
    {
        var outer = new[] { 1, 2, 3 };
        var inner = new[] { (Key: 2, Val: "two"), (Key: 3, Val: "three") };

        var result = (await T(outer).Join(
            inner,
            o => o,
            i => i.Key,
            (o, i) => $"{o}={i.Val}")).ToList();

        result.Should().Equal("2=two", "3=three");
    }

    [Fact]
    public async Task Join_NoMatches_ReturnsEmpty()
    {
        var outer = new[] { 1, 2 };
        var inner = new[] { (Key: 3, Val: "three") };

        var result = (await T(outer).Join(
            inner,
            o => o,
            i => i.Key,
            (o, i) => $"{o}={i.Val}")).ToList();

        result.Should().BeEmpty();
    }

    [Fact]
    public async Task Join_WithComparer_UsesComparer()
    {
        var outer = new[] { "A" };
        var inner = new[] { "a" };

        var result = (await T(outer).Join(
            inner,
            o => o,
            i => i,
            (o, i) => $"{o}+{i}",
            StringComparer.OrdinalIgnoreCase)).ToList();

        result.Should().Equal("A+a");
    }
}

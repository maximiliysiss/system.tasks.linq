using System.Collections;
using System.Tasks.Linq.Extensions;
using FluentAssertions;
using Xunit;

namespace System.Tasks.Linq.UnitTests;

public class ConversionExtensionsTests
{
    private static Task<IEnumerable<T>> T<T>(IEnumerable<T> source) =>
        Task.FromResult(source);

    private static Task<IEnumerable> TObj(IEnumerable source) =>
        Task.FromResult(source);

    // AsEnumerable

    [Fact]
    public async Task AsEnumerable_ReturnsSourceAsEnumerable()
    {
        var source = new[] { 1, 2, 3 };
        var result = await T(source).AsEnumerable();
        result.Should().Equal(source);
    }

    // Cast

    [Fact]
    public async Task Cast_CastsElementsToTargetType()
    {
        IEnumerable source = new object[] { 1, 2, 3 };
        var result = await TObj(source).Cast<int>();
        result.Should().Equal(1, 2, 3);
    }

    [Fact]
    public async Task Cast_InvalidCast_Throws()
    {
        IEnumerable source = new object[] { "a", "b" };
        var act = async () => (await TObj(source).Cast<int>()).ToList();
        await act.Should().ThrowAsync<InvalidCastException>();
    }

    // OfType

    [Fact]
    public async Task OfType_FiltersToMatchingType()
    {
        IEnumerable source = new object[] { 1, "a", 2, "b", 3 };
        var result = await TObj(source).OfType<int>();
        result.Should().Equal(1, 2, 3);
    }

    [Fact]
    public async Task OfType_NoMatchingElements_ReturnsEmpty()
    {
        IEnumerable source = new object[] { "a", "b" };
        var result = await TObj(source).OfType<int>();
        result.Should().BeEmpty();
    }

    // ToArray

    [Fact]
    public async Task ToArray_ReturnsArrayWithAllElements()
    {
        var result = await T([1, 2, 3]).ToArray();
        result.Should().BeOfType<int[]>().And.Equal(1, 2, 3);
    }

    [Fact]
    public async Task ToArray_EmptySequence_ReturnsEmptyArray()
    {
        var result = await T(Array.Empty<int>()).ToArray();
        result.Should().BeEmpty();
    }

    // ToDictionary

    [Fact]
    public async Task ToDictionary_KeySelector_CreatesDictionaryByKey()
    {
        var source = new[] { "apple", "banana", "cherry" };
        var result = await T(source).ToDictionary(s => s[0]);
        result.Should().HaveCount(3);
        result['a'].Should().Be("apple");
        result['b'].Should().Be("banana");
    }

    [Fact]
    public async Task ToDictionary_KeyAndElementSelector_CreatesDictionary()
    {
        var source = new[] { "apple", "banana" };
        var result = await T(source).ToDictionary(s => s[0], s => s.Length);
        result['a'].Should().Be(5);
        result['b'].Should().Be(6);
    }

    [Fact]
    public async Task ToDictionary_DuplicateKeys_Throws()
    {
        var source = new[] { "apple", "avocado" };
        var act = async () => await T(source).ToDictionary(s => s[0]);
        await act.Should().ThrowAsync<ArgumentException>();
    }

    [Fact]
    public async Task ToDictionary_WithComparer_UsesComparer()
    {
        var source = new[] { "Apple", "Banana" };
        var result = await T(source).ToDictionary(s => s, StringComparer.OrdinalIgnoreCase);
        result.ContainsKey("apple").Should().BeTrue();
    }

    // ToList

    [Fact]
    public async Task ToList_ReturnsListWithAllElements()
    {
        var result = await T([1, 2, 3]).ToList();
        result.Should().BeOfType<List<int>>().And.Equal(1, 2, 3);
    }

    [Fact]
    public async Task ToList_EmptySequence_ReturnsEmptyList()
    {
        var result = await T(Array.Empty<string>()).ToList();
        result.Should().BeEmpty();
    }

    // ToLookup

    [Fact]
    public async Task ToLookup_KeySelector_GroupsByKey()
    {
        var source = new[] { 1, 2, 3, 4 };
        var result = await T(source).ToLookup(x => x % 2 == 0 ? "even" : "odd");
        result["even"].Should().Equal(2, 4);
        result["odd"].Should().Equal(1, 3);
    }

    [Fact]
    public async Task ToLookup_KeyAndElementSelector_GroupsProjectedElements()
    {
        var source = new[] { "apple", "avocado", "banana" };
        var result = await T(source).ToLookup(s => s[0], s => s.ToUpper());
        result['a'].Should().Equal("APPLE", "AVOCADO");
        result['b'].Should().Equal("BANANA");
    }

    [Fact]
    public async Task ToLookup_WithComparer_UsesComparer()
    {
        var source = new[] { "Apple", "apple", "Banana" };
        var result = await T(source).ToLookup(s => s, StringComparer.OrdinalIgnoreCase);
        result["apple"].Should().HaveCount(2);
    }
}

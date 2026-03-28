using System.Tasks.Linq.Extensions;
using FluentAssertions;
using Xunit;

namespace System.Tasks.Linq.UnitTests;

public class AggregationExtensionsTests
{
    private static Task<IEnumerable<T>> T<T>(IEnumerable<T> source) => Task.FromResult(source);

    // Aggregate

    [Fact]
    public async Task Aggregate_NoSeed_ReturnsCombinedResult()
    {
        var result = await T([1, 2, 3, 4]).Aggregate((a, b) => a + b);
        result.Should().Be(10);
    }

    [Fact]
    public async Task Aggregate_NoSeed_EmptySequence_Throws()
    {
        var act = async () => await T(Array.Empty<int>()).Aggregate((a, b) => a + b);
        await act.Should().ThrowAsync<InvalidOperationException>();
    }

    [Fact]
    public async Task Aggregate_WithSeed_ReturnsAccumulatedResult()
    {
        var result = await T([1, 2, 3]).Aggregate(10, (acc, x) => acc + x);
        result.Should().Be(16);
    }

    [Fact]
    public async Task Aggregate_WithSeed_EmptySequence_ReturnsSeed()
    {
        var result = await T(Array.Empty<int>()).Aggregate(42, (acc, x) => acc + x);
        result.Should().Be(42);
    }

    [Fact]
    public async Task Aggregate_WithSeedAndResultSelector_ReturnsTransformedResult()
    {
        var result = await T(["a", "b", "c"])
            .Aggregate(
                new List<string>(),
                (acc, x) =>
                {
                    acc.Add(x);
                    return acc;
                },
                acc => string.Join(",", acc));
        result.Should().Be("a,b,c");
    }

    // Average

    [Fact]
    public async Task Average_Double_ReturnsCorrectAverage()
    {
        var result = await T([1.0, 2.0, 3.0]).Average();
        result.Should().Be(2.0);
    }

    [Fact]
    public async Task Average_Int_ReturnsCorrectAverage()
    {
        var result = await T([1, 2, 3]).Average();
        result.Should().Be(2.0);
    }

    [Fact]
    public async Task Average_Long_ReturnsCorrectAverage()
    {
        var result = await T([1L, 2L, 3L]).Average();
        result.Should().Be(2.0);
    }

    [Fact]
    public async Task Average_Float_ReturnsCorrectAverage()
    {
        var result = await T([1f, 2f, 3f]).Average();
        result.Should().Be(2f);
    }

    [Fact]
    public async Task Average_Decimal_ReturnsCorrectAverage()
    {
        var result = await T([1m, 2m, 3m]).Average();
        result.Should().Be(2m);
    }

    [Fact]
    public async Task Average_NullableInt_WithNulls_IgnoresNulls()
    {
        var result = await T(new int?[] { 1, null, 3 }).Average();
        result.Should().Be(2.0);
    }

    [Fact]
    public async Task Average_NullableDecimal_AllNull_ReturnsNull()
    {
        var result = await T(new decimal?[] { null, null }).Average();
        result.Should().BeNull();
    }

    [Fact]
    public async Task Average_WithSelector_Double_ReturnsCorrectAverage()
    {
        var result = await T(["a", "bb", "ccc"]).Average(s => (double)s.Length);
        result.Should().Be(2.0);
    }

    [Fact]
    public async Task Average_WithSelector_Int_ReturnsCorrectAverage()
    {
        var result = await T(["a", "bb", "ccc"]).Average(s => s.Length);
        result.Should().Be(2.0);
    }

    // Count

    [Fact]
    public async Task Count_ReturnsElementCount()
    {
        var result = await T([1, 2, 3]).Count();
        result.Should().Be(3);
    }

    [Fact]
    public async Task Count_EmptySequence_ReturnsZero()
    {
        var result = await T(Array.Empty<int>()).Count();
        result.Should().Be(0);
    }

    [Fact]
    public async Task Count_WithPredicate_ReturnsMatchingCount()
    {
        var result = await T([1, 2, 3, 4]).Count(x => x % 2 == 0);
        result.Should().Be(2);
    }

    // LongCount

    [Fact]
    public async Task LongCount_ReturnsElementCount()
    {
        var result = await T(["a", "b"]).LongCount();
        result.Should().Be(2L);
    }

    [Fact]
    public async Task LongCount_WithPredicate_ReturnsMatchingCount()
    {
        var result = await T([1, 2, 3]).LongCount(x => x > 1);
        result.Should().Be(2L);
    }

    // Max

    [Fact]
    public async Task Max_Int_ReturnsMaxValue()
    {
        var result = await T([3, 1, 4, 1, 5]).Max();
        result.Should().Be(5);
    }

    [Fact]
    public async Task Max_Double_ReturnsMaxValue()
    {
        var result = await T([1.5, 2.5, 0.5]).Max();
        result.Should().Be(2.5);
    }

    [Fact]
    public async Task Max_Long_ReturnsMaxValue()
    {
        var result = await T([1L, 3L, 2L]).Max();
        result.Should().Be(3L);
    }

    [Fact]
    public async Task Max_Float_ReturnsMaxValue()
    {
        var result = await T([1f, 3f, 2f]).Max();
        result.Should().Be(3f);
    }

    [Fact]
    public async Task Max_Decimal_ReturnsMaxValue()
    {
        var result = await T([1m, 3m, 2m]).Max();
        result.Should().Be(3m);
    }

    [Fact]
    public async Task Max_NullableInt_WithNulls_ReturnsMaxNonNull()
    {
        var result = await T(new int?[] { 1, null, 3 }).Max();
        result.Should().Be(3);
    }

    [Fact]
    public async Task Max_Generic_ReturnsMaxValue()
    {
        var result = await T(["apple", "banana", "cherry"]).Max();
        result.Should().Be("cherry");
    }

    [Fact]
    public async Task Max_WithIntSelector_ReturnsMaxProjected()
    {
        var result = await T(["a", "bb", "ccc"]).Max(s => s.Length);
        result.Should().Be(3);
    }

    [Fact]
    public async Task Max_WithResultSelector_ReturnsMaxProjected()
    {
        var result = await T(["a", "bb", "ccc"]).Max<string, string>(s => s);
        result.Should().Be("ccc");
    }

    // Min

    [Fact]
    public async Task Min_Int_ReturnsMinValue()
    {
        var result = await T([3, 1, 4]).Min();
        result.Should().Be(1);
    }

    [Fact]
    public async Task Min_Double_ReturnsMinValue()
    {
        var result = await T([1.5, 2.5, 0.5]).Min();
        result.Should().Be(0.5);
    }

    [Fact]
    public async Task Min_Long_ReturnsMinValue()
    {
        var result = await T([1L, 3L, 2L]).Min();
        result.Should().Be(1L);
    }

    [Fact]
    public async Task Min_Float_ReturnsMinValue()
    {
        var result = await T([1f, 3f, 2f]).Min();
        result.Should().Be(1f);
    }

    [Fact]
    public async Task Min_Decimal_ReturnsMinValue()
    {
        var result = await T([1m, 3m, 2m]).Min();
        result.Should().Be(1m);
    }

    [Fact]
    public async Task Min_NullableDouble_WithNulls_ReturnsMinNonNull()
    {
        var result = await T(new double?[] { 3.0, null, 1.0 }).Min();
        result.Should().Be(1.0);
    }

    [Fact]
    public async Task Min_Generic_ReturnsMinValue()
    {
        var result = await T(["banana", "apple", "cherry"]).Min();
        result.Should().Be("apple");
    }

    [Fact]
    public async Task Min_WithIntSelector_ReturnsMinProjected()
    {
        var result = await T(["a", "bb", "ccc"]).Min(s => s.Length);
        result.Should().Be(1);
    }

    [Fact]
    public async Task Min_WithResultSelector_ReturnsMinProjected()
    {
        var result = await T(["banana", "apple", "cherry"]).Min<string, string>(s => s);
        result.Should().Be("apple");
    }

    // Sum

    [Fact]
    public async Task Sum_Int_ReturnsTotal()
    {
        var result = await T([1, 2, 3]).Sum();
        result.Should().Be(6);
    }

    [Fact]
    public async Task Sum_Double_ReturnsTotal()
    {
        var result = await T([1.0, 2.0, 3.0]).Sum();
        result.Should().Be(6.0);
    }

    [Fact]
    public async Task Sum_Long_ReturnsTotal()
    {
        var result = await T([1L, 2L, 3L]).Sum();
        result.Should().Be(6L);
    }

    [Fact]
    public async Task Sum_Float_ReturnsTotal()
    {
        var result = await T([1f, 2f, 3f]).Sum();
        result.Should().Be(6f);
    }

    [Fact]
    public async Task Sum_Decimal_ReturnsTotal()
    {
        var result = await T([1m, 2m, 3m]).Sum();
        result.Should().Be(6m);
    }

    [Fact]
    public async Task Sum_NullableInt_WithNulls_IgnoresNulls()
    {
        var result = await T(new int?[] { 1, null, 3 }).Sum();
        result.Should().Be(4);
    }

    [Fact]
    public async Task Sum_EmptySequence_ReturnsZero()
    {
        var result = await T(Array.Empty<int>()).Sum();
        result.Should().Be(0);
    }

    [Fact]
    public async Task Sum_WithIntSelector_ReturnsSumOfProjected()
    {
        var result = await T(["a", "bb", "ccc"]).Sum(s => s.Length);
        result.Should().Be(6);
    }

    [Fact]
    public async Task Sum_WithDecimalSelector_ReturnsSumOfProjected()
    {
        var result = await T(["a", "bb", "ccc"]).Sum(s => (decimal)s.Length);
        result.Should().Be(6m);
    }
}

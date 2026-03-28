# System.Tasks.Linq

LINQ extension methods for `Task<IEnumerable<T>>`. Chain async data-returning operations without intermediate `await` expressions — the full LINQ surface, lifted into task space.

## Installation

```
dotnet add package Itselves.Tasks.Linq
```

## Compatibility

`netstandard2.0` — works on .NET Framework 4.6.1+, .NET Core 2.0+, .NET 5+, Xamarin, Unity.

## Usage

Add the using and call LINQ methods directly on any `Task<IEnumerable<T>>`:

```csharp
using System.Tasks.Linq.Extensions;

// Without System.Tasks.Linq
var result = (await GetOrdersAsync()).Where(o => o.IsActive).Select(o => o.Total).Sum();

// With System.Tasks.Linq
var result = await GetOrdersAsync().Where(o => o.IsActive).Select(o => o.Total).Sum();
```

The `await` moves to the end of the chain. Each operator awaits the task internally, applies the standard LINQ operation, and returns a new `Task` for the next operator to consume.

### Working with other collection types

Methods returning `Task<List<T>>`, `Task<T[]>`, or any other collection type expose `AsEnumerable()` to widen to `Task<IEnumerable<T>>`, after which all LINQ operators are available:

```csharp
// Task<List<T>> from EF Core ToListAsync(), Task<T[]>, Task<IReadOnlyList<T>>, etc.
var result = await GetOrdersAsync()   // Task<List<Order>>
    .AsEnumerable()                   // Task<IEnumerable<Order>>
    .Where(o => o.IsActive)
    .Select(o => o.Total)
    .Sum();
```

`AsEnumerable()` is provided for:

| Type | Common source |
|---|---|
| `Task<IReadOnlyCollection<T>>` | Read-only APIs, domain models |
| `Task<IReadOnlyList<T>>` | Read-only indexed APIs |
| `Task<ICollection<T>>` | Mutable collection interfaces |
| `Task<IList<T>>` | Mutable indexed interfaces |
| `Task<List<T>>` | EF Core `ToListAsync()`, most ORMs |
| `Task<T[]>` | `ToArrayAsync()`, fixed-size results |

## API reference

All standard `System.Linq.Enumerable` operators are available on `Task<IEnumerable<T>>`.

### Aggregation

```csharp
Task<TSource>     Aggregate(func)
Task<TAccumulate> Aggregate(seed, func)
Task<TResult>     Aggregate(seed, func, resultSelector)

Task<double>      Average()   // int, long, float, double, decimal + nullable variants
Task<double>      Average(selector)

Task<int>         Count()
Task<int>         Count(predicate)
Task<long>        LongCount()
Task<long>        LongCount(predicate)

Task<T>           Max()       // int, long, float, double, decimal + nullable + generic
Task<T>           Max(selector)
Task<T>           Min()       // same overloads as Max
Task<T>           Min(selector)

Task<T>           Sum()       // int, long, float, double, decimal + nullable variants
Task<T>           Sum(selector)
```

### Filtering

```csharp
Task<bool>              All(predicate)
Task<bool>              Any()
Task<bool>              Any(predicate)
Task<bool>              Contains(value, comparer?)
Task<bool>              SequenceEqual(second, comparer?)
Task<IEnumerable<T>>    Where(predicate)
Task<IEnumerable<T>>    Where((element, index) => predicate)
```

### Projection

```csharp
Task<IEnumerable<TResult>> Select(selector)
Task<IEnumerable<TResult>> Select((element, index) => selector)
Task<IEnumerable<TResult>> SelectMany(selector)
Task<IEnumerable<TResult>> SelectMany((element, index) => selector)
Task<IEnumerable<TResult>> SelectMany(collectionSelector, resultSelector)
Task<IEnumerable<TResult>> SelectMany((element, index) => collectionSelector, resultSelector)
```

### Element access

```csharp
Task<T>  ElementAt(index)
Task<T?> ElementAtOrDefault(index)
Task<T>  First()
Task<T>  First(predicate)
Task<T?> FirstOrDefault()
Task<T?> FirstOrDefault(predicate)
Task<T>  Last()
Task<T>  Last(predicate)
Task<T?> LastOrDefault()
Task<T?> LastOrDefault(predicate)
Task<T>  Single()
Task<T>  Single(predicate)
Task<T?> SingleOrDefault()
Task<T?> SingleOrDefault(predicate)
```

### Ordering

```csharp
Task<IOrderedEnumerable<T>> OrderBy(keySelector, comparer?)
Task<IOrderedEnumerable<T>> OrderByDescending(keySelector, comparer?)
Task<IEnumerable<T>>        Reverse()
```

`OrderBy` and `OrderByDescending` return `IOrderedEnumerable<T>`, so `.ThenBy()` / `.ThenByDescending()` work normally after awaiting.

### Partitioning

```csharp
Task<IEnumerable<T>> Append(element)
Task<IEnumerable<T>> Prepend(element)
Task<IEnumerable<T>> DefaultIfEmpty()
Task<IEnumerable<T>> DefaultIfEmpty(defaultValue)
Task<IEnumerable<T>> Skip(count)
Task<IEnumerable<T>> SkipWhile(predicate)
Task<IEnumerable<T>> SkipWhile((element, index) => predicate)
Task<IEnumerable<T>> Take(count)
Task<IEnumerable<T>> TakeWhile(predicate)
Task<IEnumerable<T>> TakeWhile((element, index) => predicate)
```

### Grouping and joining

```csharp
Task<IEnumerable<IGrouping<TKey, T>>>  GroupBy(keySelector, comparer?)
Task<IEnumerable<IGrouping<TKey, E>>>  GroupBy(keySelector, elementSelector, comparer?)
Task<IEnumerable<TResult>>             GroupBy(keySelector, resultSelector, comparer?)
Task<IEnumerable<TResult>>             GroupBy(keySelector, elementSelector, resultSelector, comparer?)

Task<IEnumerable<TResult>>             GroupJoin(inner, outerKey, innerKey, resultSelector, comparer?)
Task<IEnumerable<TResult>>             Join(inner, outerKey, innerKey, resultSelector, comparer?)
```

### Set operations

```csharp
Task<IEnumerable<T>> Concat(second)
Task<IEnumerable<T>> Distinct(comparer?)
Task<IEnumerable<T>> Except(second, comparer?)
Task<IEnumerable<T>> Intersect(second, comparer?)
Task<IEnumerable<T>> Union(second, comparer?)
```

### Conversion

```csharp
Task<IEnumerable<T>>               AsEnumerable()
Task<IEnumerable<TResult>>         Cast<TResult>()          // Task<IEnumerable> (non-generic source)
Task<IEnumerable<TResult>>         OfType<TResult>()        // Task<IEnumerable> (non-generic source)
Task<T[]>                          ToArray()
Task<List<T>>                      ToList()
Task<Dictionary<TKey, T>>          ToDictionary(keySelector, comparer?)
Task<Dictionary<TKey, TElement>>   ToDictionary(keySelector, elementSelector, comparer?)
Task<ILookup<TKey, T>>             ToLookup(keySelector, comparer?)
Task<ILookup<TKey, TElement>>      ToLookup(keySelector, elementSelector, comparer?)
```

`Cast` and `OfType` are only available on `Task<IEnumerable>` (the non-generic interface) because they are type-changing operations that require an untyped source.

### Zip

```csharp
Task<IEnumerable<TResult>> Zip(second, resultSelector)
```

## Examples

**Pipeline with multiple operators**

```csharp
var topSpenders = await dbContext.GetCustomersAsync()
    .Where(c => c.IsActive)
    .SelectMany(c => c.Orders)
    .GroupBy(o => o.CustomerId, o => o.Total, (id, totals) => (id, total: totals.Sum()))
    .OrderByDescending(x => x.total)
    .Take(10)
    .ToList();
```

**Starting from a `Task<List<T>>`**

```csharp
double average = await repository.GetTransactionsAsync()  // Task<List<Transaction>>
    .AsEnumerable()
    .Where(t => t.Date >= DateTime.Today.AddDays(-30))
    .Average(t => t.Amount);
```

**Chaining OrderBy with ThenBy**

```csharp
var sorted = (await GetProductsAsync().OrderBy(p => p.Category))
    .ThenBy(p => p.Name);
```

## Behaviour notes

- Every operator awaits the upstream `Task<IEnumerable<T>>` exactly once and delegates directly to the corresponding `System.Linq.Enumerable` method. There is no buffering or side-effect beyond what standard LINQ does.
- Other collection types (`List<T>`, `T[]`, `IReadOnlyList<T>`, etc.) expose only `AsEnumerable()`, which upcasts to `Task<IEnumerable<T>>`. All LINQ logic lives in one place — there is no duplication across collection types.
- Exceptions from the underlying task propagate normally when awaited.
- Deferred LINQ operators (`Where`, `Select`, `SelectMany`, etc.) remain deferred — the selector/predicate runs when the result is enumerated, not when the task is awaited.
- Operators that throw on invalid input (`First`, `Single`, `ElementAt`, `Aggregate` without seed on empty sequence, etc.) preserve the same exception semantics as their `Enumerable` counterparts.

using System.Collections;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2021.Tests.Unit;

public class Day6Tests
{
    [Theory]
    [ClassData(typeof(Day6Part1TestData))]
    public void Part1_ShouldReturnInteger_WhenEnumberableAreStrings(string[] values, int days, int expected)
    {
        // Act
        var result = Day6.Part1(values, days);

        // Assert 
        result.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(Day6Part2TestData))]
    public void Part2_ShouldReturnLong_WhenEnumberableAreStrings(string[] values, int days, long expected)
    {
        // Act
        var result = Day6.Part2(values, days);

        // Assert 
        result.Should().Be(expected);
    }
}

public class Day6Part1TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new string[]
            {
                "3,4,3,1,2",
            },
            18,
            26
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Day6Part2TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new string[]
            {
                "3,4,3,1,2",
            },
            256,
            26984457539
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

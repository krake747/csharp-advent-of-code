using System.Collections;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2021.Tests.Unit;

public class Day7Tests
{
    [Theory]
    [ClassData(typeof(Day7Part1TestData))]
    public void Part1_ShouldReturnInteger_WhenEnumerableAreStrings(string[] values, int expected)
    {
        // Act
        var result = Day7.Part1(values);

        // Assert 
        result.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(Day7Part2TestData))]
    public void Part2_ShouldReturnInteger_WhenEnumerableAreStrings(string[] values, int expected)
    {
        // Act
        var result = Day7.Part2(values);

        // Assert 
        result.Should().Be(expected);
    }
}


public class Day7Part1TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new string[]
            {
                "16,1,2,0,4,2,7,1,2,14",
            },
            37
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Day7Part2TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new string[]
            {
                "16,1,2,0,4,2,7,1,2,14",
            },
            168
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

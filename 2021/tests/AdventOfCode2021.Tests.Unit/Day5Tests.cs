using System.Collections;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2021.Tests.Unit;

public class Day5Tests
{
    [Theory]
    [ClassData(typeof(Day5Part1TestData))]
    public void Part1_ShouldReturnInteger_WhenEnumberableAreStrings(string[] values, int expected)
    {
        // Act
        var result = Day5.Part1(values);

        // Assert 
        result.Should().Be(expected);
    }
}


public class Day5Part1TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new string[]
            {
                "0,9 -> 5,9",
                "8,0 -> 0,8",
                "9,4 -> 3,4",
                "2,2 -> 2,1",
                "7,0 -> 7,4",
                "6,4 -> 2,0",
                "0,9 -> 2,9",
                "3,4 -> 1,4",
                "0,0 -> 8,8",
                "5,5 -> 8,2"
            },
            5
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

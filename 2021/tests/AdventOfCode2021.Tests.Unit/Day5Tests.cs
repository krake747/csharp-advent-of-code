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

    [Theory]
    [ClassData(typeof(Day5Part2TestData))]
    public void Part2_ShouldReturnInteger_WhenEnumberableAreStrings(string[] values, int expected)
    {
        // Act
        var result = Day5.Part2(values);

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
                "0,9 -> 5,9", // Horizontal
                "8,0 -> 0,8", // Antidiagonal
                "9,4 -> 3,4", // Horizontal
                "2,2 -> 2,1", // Vertical
                "7,0 -> 7,4", // Vertical
                "6,4 -> 2,0", // Diagonal
                "0,9 -> 2,9", // Horizontal
                "3,4 -> 1,4", // Horizontal
                "0,0 -> 8,8", // Diagonal
                "5,5 -> 8,2"  // Antidiagonal
            },
            5
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Day5Part2TestData : IEnumerable<object[]>
{
    public IEnumerator<object[]> GetEnumerator()
    {
        yield return new object[]
        {
            new string[]
            {
                "0,9 -> 5,9", // Horizontal
                "8,0 -> 0,8", // Antidiagonal
                "9,4 -> 3,4", // Horizontal
                "2,2 -> 2,1", // Vertical
                "7,0 -> 7,4", // Vertical
                "6,4 -> 2,0", // Diagonal
                "0,9 -> 2,9", // Horizontal
                "3,4 -> 1,4", // Horizontal
                "0,0 -> 8,8", // Diagonal
                "5,5 -> 8,2"  // Antidiagonal
            },
            12
        };
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

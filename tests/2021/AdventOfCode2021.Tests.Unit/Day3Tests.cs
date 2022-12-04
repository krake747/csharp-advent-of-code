using Xunit;
using FluentAssertions;

namespace AdventOfCode2021.Tests.Unit;

public class Day3Tests
{
    [Theory]
    [InlineData(new string[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" }, 198)]
    public void Part1_ShouldReturnInteger_WhenEnumerableAreStrings(string[] values, int expected)
    {
        // Act
        var result = Day3.Part1(values);

        // Assert 
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(new string[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" }, 230)]
    public void Part2_ShouldReturnInteger_WhenEnumerableAreStrings(string[] values, int expected)
    {
        // Act
        var result = Day3.Part2(values);

        // Assert 
        result.Should().Be(expected);
    }
}
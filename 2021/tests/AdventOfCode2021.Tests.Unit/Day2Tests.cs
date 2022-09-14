using Xunit;
using FluentAssertions;

namespace AdventOfCode2021.Tests.Unit;

public class Day2Tests
{
    [Theory]
    [InlineData(new string[] { }, 0)]
    [InlineData(new string[] { "forward 5" }, 0)]
    [InlineData(new string[] { "forward 5", "down 5" }, 25)]
    [InlineData(new string[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" }, 150)]
    public void Day2_Part1_ShouldReturnInteger_WhenEnumberableAreStrings(string[] values, int expected)
    {
        // Act
        var result = Day2.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(new string[] { }, 0)]
    [InlineData(new string[] { "forward 5" }, 0)]
    [InlineData(new string[] { "forward 5", "down 5" }, 0)]
    [InlineData(new string[] { "forward 5", "down 5", "forward 8" }, 520)]
    [InlineData(new string[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" }, 900)]
    public void Day2_Part2_ShouldReturnInteger_WhenEnumberableAreStrings(string[] values, int expected)
    {
        // Act
        var result = Day2.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}
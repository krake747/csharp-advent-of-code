using Xunit;
using FluentAssertions;

namespace AdventOfCode2021.Tests.Unit;

public class AdventOfCode2021Tests
{
    [Theory]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { 199 }, 0)]
    [InlineData(new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, 7)]
    public void Day1_Part1_ShouldReturnInteger_WhenEnumberableIsInteger(int[] values, int expected)
    {
        // Act
        var result = Day1.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { 199 }, 0)]
    [InlineData(new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, 5)]
    public void Day1_Part2__ShouldReturnInteger_WhenEnumberableIsInteger(int[] values, int expected)
    {
        // Act
        var result = Day1.Part2(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [InlineData(new string[] { }, 0, 0, 0)]
    [InlineData(new string[] { "forward 5" }, 0, 0, 0)]
    [InlineData(new string[] { "forward 5", "down 5" }, 0, 0, -25)]
    [InlineData(new string[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" }, 0, 0, -150)]
    public void Day2_Part1_ShouldReturnInteger_WhenEnumberableIsStringAndStartingPositionsAreInteger(string[] values, int x, int y, int expected)
    {
        // Act
        var result = Day2.Part1(values, x, y);

        // Assert
        result.Should().Be(expected);
    }
}
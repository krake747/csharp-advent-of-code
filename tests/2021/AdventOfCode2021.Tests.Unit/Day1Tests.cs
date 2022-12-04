using Xunit;
using FluentAssertions;

namespace AdventOfCode2021.Tests.Unit;

public class Day1Tests
{
    [Theory]
    [InlineData(new int[] { }, 0)]
    [InlineData(new int[] { 199 }, 0)]
    [InlineData(new int[] { 199, 200, 208, 210, 200, 207, 240, 269, 260, 263 }, 7)]
    public void Part1_ShouldReturnInteger_WhenEnumerableIsInteger(int[] values, int expected)
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
    public void Part2__ShouldReturnInteger_WhenEnumerableIsInteger(int[] values, int expected)
    {
        // Act
        var result = Day1.Part2(values);

        // Assert
        result.Should().Be(expected);
    }
}
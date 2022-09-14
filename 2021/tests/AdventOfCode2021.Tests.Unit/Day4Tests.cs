using Xunit;
using FluentAssertions;
using AdventOfCode2021.Shared;

namespace AdventOfCode2021.Tests.Unit;

public class Day4Tests
{
    [Theory]
    [InlineData("day04.txt", 4512)]
    public void Part1_ShouldReturnInteger_WhenEnumberableAreStrings(string file, int expected)
    {
        // Arrange
        var parser = new TextFileParserService();
        var input = parser.Fetch(file);

        // Act
        var result = Day4.Part1(input);

        // Assert 
        result.Should().Be(expected);
    }
}

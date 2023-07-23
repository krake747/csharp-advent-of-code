using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2020.Tests.Unit;

[Description("Day 06 - Custom Customs")]
public sealed class Day06Tests
{
    private const string Day = nameof(Day06);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day06 _sut;

    public Day06Tests()
    {
        // Arrange
        _sut = new Day06();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 11 },
        { ReadInput(RealData), 7027 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 6 },
        { ReadInput(RealData), 3579 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Count the number of questions to which anyone answered yes. What is the sum of those counts?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day06.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("Count the number of questions to which everyone answered yes. What is the sum of those counts?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day06.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
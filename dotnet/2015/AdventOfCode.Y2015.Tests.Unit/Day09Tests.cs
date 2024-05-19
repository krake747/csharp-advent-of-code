using System.ComponentModel;
using AdventOfCode.Lib;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2015.Tests.Unit;

[AocPuzzle(2015, 9, "All in a Single Night")]
public sealed class Day09Tests
{
    private const string Day = nameof(Day09);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day09 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 605 },
        { ReadInput(RealData), 207 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 982 },
        { ReadInput(RealData), 804 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the distance of the shortest route?")]
    public void Part1_ShouldReturnInteger_WhenSantaChoosesShortestDistance(AocInput input, int expected)
    {
        // Act
        var result = Day09.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("")]
    public void Part2_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Day09.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
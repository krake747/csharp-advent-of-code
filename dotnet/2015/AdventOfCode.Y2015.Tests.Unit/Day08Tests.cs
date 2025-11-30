using System.ComponentModel;
using AdventOfCode.Lib;
using AwesomeAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2015.Tests.Unit;

[AocPuzzle(2015, 8, "Matchsticks")]
public sealed class Day08Tests
{
    private const string Day = nameof(Day08);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day08 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 12 },
        { ReadInput(RealData), 1342 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 19 },
        { ReadInput(RealData), 2074 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the number of characters of code minus the number of characters in memory?")]
    public void Part1_ShouldReturnInteger_WhenSantaCalculatesSpaceOnSleigh(AocInput input, int expected)
    {
        // Act
        var result = Day08.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the number of characters of new code minus the number of characters in original?")]
    public void Part2_ShouldReturnInteger_WhenSantaCalculatesSpaceOnSleigh(AocInput input, int expected)
    {
        // Act
        var result = Day08.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
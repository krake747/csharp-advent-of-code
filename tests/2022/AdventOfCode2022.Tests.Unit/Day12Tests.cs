using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[AocPuzzle(2022, 12, "Hill Climbing Algorithm")]
public sealed class Day12Tests
{
    private readonly Day12 _sut;
    private const string Day = nameof(Day12);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 1 },
        { ReadInput(RealData), 1 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 1 },
        { ReadInput(RealData), 1 }
    };
    
    public Day12Tests()
    {
        // Arrange
        _sut = new Day12();
    }

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the fewest steps required to move from your current position to the location that should " +
                 "get the best signal?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day12.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the fewest steps required to move from your current position to the location that should " +
                 "get the best signal?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day12.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
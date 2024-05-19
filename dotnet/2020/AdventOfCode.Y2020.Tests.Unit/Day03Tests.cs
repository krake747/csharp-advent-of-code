using System.ComponentModel;
using AdventOfCode.Lib;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2020.Tests.Unit;

[Description("Day 03 - Toboggan Trajectory")]
public sealed class Day03Tests
{
    private const string Day = nameof(Day03);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day03 _sut;

    public Day03Tests()
    {
        _sut = new Day03();
    }

    public static TheoryData<AocInput, long> Part1Data => new()
    {
        { ReadInput(TestData), 7 },
        { ReadInput(RealData), 214 }
    };

    public static TheoryData<AocInput, long> Part2Data => new()
    {
        { ReadInput(TestData), 336 },
        { ReadInput(RealData), 8336352024L }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Following a slope of right 3 and down 1, how many trees would you encounter?")]
    public void Part1_ShouldReturnLong(AocInput input, long expected)
    {
        // Act
        var result = Day03.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What do you get if you multiply together the number of trees encountered on each of the slopes?")]
    public void Part2_ShouldReturnLong(AocInput input, long expected)
    {
        // Act
        var result = Day03.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
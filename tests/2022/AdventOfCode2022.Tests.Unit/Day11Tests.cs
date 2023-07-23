using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[AocPuzzle(2022, 11, "Monkey in the Middle")]
public sealed class Day11Tests
{
    private const string Day = nameof(Day11);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day11 _sut;

    public Day11Tests()
    {
        _sut = new Day11();
    }

    public static TheoryData<AocInput, long> Part1Data => new()
    {
        { ReadInput(TestData), 10605L },
        { ReadInput(RealData), 56120L }
    };

    public static TheoryData<AocInput, long> Part2Data => new()
    {
        { ReadInput(TestData), 2713310158L },
        { ReadInput(RealData), 24389045529L }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the level of monkey business after 20 rounds of stuff-slinging simian shenanigans?")]
    public void Part1_ShouldReturnInteger(AocInput input, long expected)
    {
        // Act
        var result = Day11.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the level of monkey business after 20 rounds of stuff-slinging simian shenanigans?")]
    public void Part2_ShouldReturnInteger(AocInput input, long expected)
    {
        // Act
        var result = Day11.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
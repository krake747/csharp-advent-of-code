using System.ComponentModel;
using AdventOfCode.Lib;
using AwesomeAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2015.Tests.Unit;

[AocPuzzle(2015, 4, "The Ideal Stocking Stuffer")]
public sealed class Day04Tests
{
    private const string Day = nameof(Day04);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day04 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 609043 },
        { ReadInput(RealData), 254575 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(RealData), 1038736 }
    };

    [Theory]
    // [Theory(Skip = ".NET 8 breaks this part 1 original results somehow. Works correctly in .NET 7")]
    [MemberData(nameof(Part1Data))]
    [Description("To mine AdventCoins, you must find Santa the lowest positive number that produces such a hash")]
    public void Part1_ShouldReturnInteger_WhenSantaMinesAdventCoins(AocInput input, int expected)
    {
        // Act
        var result = Day04.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("Now find one that starts with six zeroes")]
    public void Part2_ShouldReturnInteger_WhenSantaMinesAdventCoins2(AocInput input, int expected)
    {
        // Act
        var result = Day04.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
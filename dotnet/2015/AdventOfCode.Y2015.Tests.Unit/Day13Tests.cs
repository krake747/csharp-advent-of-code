using System.ComponentModel;
using AdventOfCode.Lib;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2015.Tests.Unit;

[AocPuzzle(2015, 13, "Knights of the Dinner Table")]
public sealed class Day13Tests
{
    private const string Day = nameof(Day13);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day13 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 330 },
        { ReadInput(RealData), 1 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 0 },
        { ReadInput(RealData), 0 }
    };

    [Theory(Skip = "unfinished")]
    [MemberData(nameof(Part1Data))]
    [Description("")]
    public void Part1_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Day13.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory(Skip = "unfinished")]
    [MemberData(nameof(Part2Data))]
    [Description("")]
    public void Part2_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Day13.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
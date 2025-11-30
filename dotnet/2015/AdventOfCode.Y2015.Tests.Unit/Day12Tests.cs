using System.ComponentModel;
using AdventOfCode.Lib;
using AwesomeAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2015.Tests.Unit;

[AocPuzzle(2015, 12, "JSAbacusFramework.io")]
public sealed class Day12Tests
{
    private const string Day = nameof(Day12);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day12 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 6 },
        { ReadInput(RealData), 119433 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 6 },
        { ReadInput(RealData), 68466 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of all numbers in the document?")]
    public void Part1_ShouldReturnInteger_WhenAccountingElvesBalanceTheBooks(AocInput input, int expected)
    {
        // Act
        var result = Day12.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("Accounting-Elves have realized that they double-counted everything red?")]
    public void Part2_ShouldReturnInteger_WhenAccountingElvesBalanceTheBooks(AocInput input, int expected)
    {
        // Act
        var result = Day12.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
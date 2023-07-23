using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[AocPuzzle(2022, 9, "Rope Bridge")]
public sealed class Day09Tests
{
    private readonly Day09 _sut;
    private const string Day = nameof(Day09);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string TestData2 = @$"..\..\..\Data\{Day}_Test_2.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 13 },
        { ReadInput(RealData), 6030 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 1 },
        { ReadInput(TestData2), 36 },
        { ReadInput(RealData), 2545 }
    };
    
    public Day09Tests()
    {
        // Arrange
        _sut = new Day09();
    }


    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many positions does the tail of the rope visit at least once?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day09.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many positions does the tail of the rope visit at least once?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day09.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
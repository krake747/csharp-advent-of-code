using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[AocPuzzle(2022, 13, "Distress Signal")]
public sealed class Day13Tests
{
    private const string Day = nameof(Day13);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day13 _sut;

    public Day13Tests()
    {
        _sut = new Day13();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 13 },
        { ReadInput(RealData), 5503 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 140 },
        { ReadInput(RealData), 20952 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Determine pairs in the right order. What is the sum of the indices of those pairs?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day13.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("Determine pairs in the right order. What is the sum of the indices of those pairs?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day13.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
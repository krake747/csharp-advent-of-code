using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2020.Tests.Unit;

[Description("Day 05 - Binary Boarding")]
public sealed class Day05Tests
{
    private const string Day = nameof(Day05);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day05 _sut;

    public Day05Tests()
    {
        _sut = new Day05();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 820 },
        { ReadInput(RealData), 930 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(RealData), 515 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the highest seat ID on a boarding pass?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day05.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the ID of your seat?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day05.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
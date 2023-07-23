using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[Description("Day 03 - Rucksack Reorganization")]
public sealed class Day03Tests
{
    private readonly Day03 _sut;
    private const string Day = nameof(Day03);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 157 },
        { ReadInput(RealData), 8202 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 70 },
        { ReadInput(RealData), 2864 }
    };
    
    public Day03Tests()
    {
        _sut = new Day03();
    }

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of the priorities of those item types?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day03.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the sum of the priorities of those item types?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day03.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
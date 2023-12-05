using System.ComponentModel;
using AdventOfCode2023.FSharp;
using AdventOfCodeLib;
using FluentAssertions;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2023.Tests.Unit;

[AocPuzzle(2023, 5, "If You Give A Seed A Fertilizer")]
public sealed class Day05Tests
{
    private const string Day = nameof(Day05);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day05 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 0 }, // 35
        { ReadInput(RealData), 0 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 0 },
        { ReadInput(RealData), 0 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the lowest location number that corresponds to any of the initial seed numbers?")]
    public void Part1_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Day05.Part1(input);
        
        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("<insert here>")]
    public void Part2_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Day05.Part2(input);
    
        // Assert
        result.Should().Be(expected);
    }
}
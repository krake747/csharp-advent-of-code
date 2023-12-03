using System.ComponentModel;
using AdventOfCodeLib;
using FluentAssertions;
using AdventOfCode2023.FSharp;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2023.Tests.Unit;

[AocPuzzle(2023, 3, "Gear Ratios")]
public sealed class Fay03Tests
{
    private const string Day = nameof(Day03);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day03 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 4361 },
        { ReadInput(RealData), 507214 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 467835 },
        { ReadInput(RealData), 72553319 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of all of the part numbers in the engine schematic?")]
    public void Part1_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Fay03.part1(input);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the sum of all of the gear ratios in your engine schematic?")]
    public void Part2_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Fay03.part2(input);
    
        // Assert
        result.Should().Be(expected);
    }
}
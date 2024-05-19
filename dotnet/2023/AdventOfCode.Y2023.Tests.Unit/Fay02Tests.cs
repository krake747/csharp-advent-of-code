using System.ComponentModel;
using AdventOfCode.Lib;
using AdventOfCode2023.FSharp;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2023.Tests.Unit;

[AocPuzzle(2023, 2, "Cube Conundrum", "F#")]
public sealed class Fay02Tests
{
    private const string Day = nameof(Day02);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day02 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 8 },
        { ReadInput(RealData), 2285 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 2286 },
        { ReadInput(RealData), 77021 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of the IDs of those games?")]
    public void Part1_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Fay02.part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the sum of the power of these sets?")]
    public void Part2_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Fay02.part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
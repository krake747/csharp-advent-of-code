using System.ComponentModel;
using AdventOfCode2023.FSharp;
using AdventOfCode.Lib;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode2023.Tests.Unit;

[AocPuzzle(2023, 1, "Trebuchet?!", "F#")]
public sealed class Fay01Tests
{
    private const string Day = nameof(Day01);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string TestData2 = @$"..\..\..\Data\{Day}_Test_2.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day01 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 142 },
        { ReadInput(RealData), 55130 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData2), 281 },
        { ReadInput(RealData), 54985 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of all of the calibration values?")]
    public void Part1_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Fays.part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("What is the sum of all of the calibration values?")]
    public void Part2_ShouldReturnInteger_WhenSample(AocInput input, int expected)
    {
        // Act
        var result = Fays.part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
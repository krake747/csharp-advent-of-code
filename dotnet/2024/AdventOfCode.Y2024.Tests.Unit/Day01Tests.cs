using System.ComponentModel;
using AdventOfCode.Lib;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2024.Tests.Unit;

[AocPuzzle(2024, 1, "Historian Hysteria")]
public sealed class Day01Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day01);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day01 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 11 },
        { ReadInput(RealData), 1660292 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 0 },
        { ReadInput(RealData), 0 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the total distance between your lists?")]
    public void Part1(AocInput input, int expected)
    {
        // Act
        var result = Day01.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("<insert question 2 here>")]
    public void Part2(AocInput input, int expected)
    {
        // Act
        var result = Day01.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
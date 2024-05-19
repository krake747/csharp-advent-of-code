using System.ComponentModel;
using AdventOfCode.Lib;
using FluentAssertions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode2023.Tests.Unit;

[AocPuzzle(2023, 15, "Lens Library")]
public sealed class Day15Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day15);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day15 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 1320 },
        { ReadInput(RealData), 510388 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 0 },
        { ReadInput(RealData), 0 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of the results?")]
    public void Part1(AocInput input, int expected)
    {
        // Act
        var result = Day15.Part1(input);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("<insert question 2 here>")]
    public void Part2(AocInput input, int expected)
    {
        // Act
        var result = Day15.Part2(input);
    
        // Assert
        result.Should().Be(expected);
    }
}
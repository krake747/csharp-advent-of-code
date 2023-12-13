using System.ComponentModel;
using AdventOfCodeLib;
using FluentAssertions;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2023.Tests.Unit;

[AocPuzzle(2023, 13, "Point of Incidence")]
public sealed class Day13Tests : IAocDayTest<int>
{
    private const string Day = nameof(Day13);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day13 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 0 },
        { ReadInput(RealData), 0 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 0 },
        { ReadInput(RealData), 0 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What number do you get after summarizing all of your notes?")]
    public void Part1(AocInput input, int expected)
    {
        // Act
        var result = Day13.Part1(input);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("<insert question 2 here>")]
    public void Part2(AocInput input, int expected)
    {
        // Act
        var result = Day13.Part2(input);
    
        // Assert
        result.Should().Be(expected);
    }
}
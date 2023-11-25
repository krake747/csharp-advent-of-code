using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2020.Tests.Unit;

[Description("Day 04 - Toboggan Trajectory")]
public sealed class Day04Tests
{
    private const string Day = nameof(Day04);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string TestValidData = @$"..\..\..\Data\{Day}_Test_Valid.txt";
    private const string TestInvalidData = @$"..\..\..\Data\{Day}_Test_Invalid.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day04 _sut;

    public Day04Tests()
    {
        _sut = new Day04();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 2 },
        { ReadInput(RealData), 170 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestInvalidData), 0 },
        { ReadInput(TestValidData), 4 },
        { ReadInput(RealData), 103 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("Count the number of valid passports. In your batch file, how many passports are valid?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day04.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("Count the number of valid passports. In your batch file, how many passports are valid?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day04.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
using System.ComponentModel;
using AdventOfCodeLib;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2020.Tests.Unit;

[Description("Day 02 - Password Philosophy")]
public sealed class Day02Tests
{
    private const string Day = nameof(Day02);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day02 _sut;

    public Day02Tests()
    {
        _sut = new Day02();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 2 },
        { ReadInput(RealData), 572 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 1 },
        { ReadInput(RealData), 306 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many passwords are valid according to their policies?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day02.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("How many passwords are valid according to the new interpretation of the policies?")]
    public void Part2_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day02.Part2(input);

        // Assert
        result.Should().Be(expected);
    }
}
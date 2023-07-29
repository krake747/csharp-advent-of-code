using System.ComponentModel;
using AdventOfCodeLib;
using FluentAssertions;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2015.Tests.Unit;

[AocPuzzle(2015, 11, "Corporate Policy")]
public sealed class Day11Tests
{
    private const string Day = nameof(Day11);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day11 _sut = new();

    public static TheoryData<AocInput, string> Part1Data => new()
    {
        // { ReadInput(TestData), "" },
        { ReadInput(RealData), "hepxxyzz" }
    };

    public static TheoryData<AocInput, string> Part2Data => new()
    {
        // { ReadInput(TestData), "" },
        { ReadInput(RealData), "heqaabcc" }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What should Santa's next password be?")]
    public void Part1_ShouldReturnInteger_WhenSantaChoosesNewPassword(AocInput input, string expected)
    {
        // Act
        var result = Day11.Part1(input);

        // Assert
        result.Should().Be(expected);
    }
    
    [Theory]
    [MemberData(nameof(Part2Data))]
    [Description("")]
    public void Part2_ShouldReturnInteger_WhenSantaChoosesNewPassword(AocInput input, string expected)
    {
        // Act
        var result = Day11.Part2(input);
    
        // Assert
        result.Should().Be(expected);
    }
}
using System.ComponentModel;
using AdventOfCodeLib;
using FluentAssertions;
using static AdventOfCodeLib.AocFileReaderService;

namespace AdventOfCode2015.Tests.Unit;

[AocPuzzle(2015, 5, "Doesn't He Have Intern-Elves For This?")]
public sealed class Day05Tests
{
    private const string Day = nameof(Day05);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day05 _sut = new();

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 1 },
        { ReadInput(RealData), 236 }
    };

    public static TheoryData<AocInput, int> Part2Data => new()
    {
        { ReadInput(TestData), 1 },
        { ReadInput(RealData), 1 }
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("How many strings are nice?")]
    public void Part1_ShouldReturnInteger_WhenSantaLooksForNaughtyAndNice(AocInput input, int expected)
    {
        // Act
        var result = Day05.Part1(input);

        // Assert
        result.Should().Be(expected);
    }
    //
    // [Theory]
    // [MemberData(nameof(Part2Data))]
    // [Description("How many strings are nice?")]
    // public void Part2_ShouldReturnInteger_WhenSantaLooksForNaughtyAndNice(AocInput input, int expected)
    // {
    //     // Act
    //     var result = Day05.Part2(input);
    //
    //     // Assert
    //     result.Should().Be(expected);
    // }
}
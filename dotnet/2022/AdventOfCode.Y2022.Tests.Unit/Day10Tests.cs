using System.ComponentModel;
using AdventOfCode.Lib;
using Xunit.Abstractions;
using static AdventOfCode.Lib.AocFileReaderService;

namespace AdventOfCode.Y2022.Tests.Unit;

[AocPuzzle(2022, 10, "Cathode-Ray Tube")]
public sealed class Day10Tests
{
    private const string Day = nameof(Day10);
    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
    private const string RealData = @$"..\..\..\Data\{Day}.txt";
    private readonly Day10 _sut;
    private readonly ITestOutputHelper _testOutputHelper;

    public Day10Tests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;

        // Arrange
        _sut = new Day10();
    }

    public static TheoryData<AocInput, int> Part1Data => new()
    {
        { ReadInput(TestData), 13140 },
        { ReadInput(RealData), 13740 }
    };

    public static TheoryData<AocInput> Part2TestData => new()
    {
        ReadInput(TestData)
    };

    public static TheoryData<AocInput> Part2RealData => new()
    {
        ReadInput(RealData)
    };

    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of these six signal strengths?")]
    public void Part1_ShouldReturnInteger(AocInput input, int expected)
    {
        // Act
        var result = Day10.Part1(input);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2TestData))]
    [Description("What eight capital letters appear on your CRT?")]
    public void Part2_ShouldWriteToOutputTestResult(AocInput input)
    {
        // Arrange
        const string expected =
            "##..##..##..##..##..##..##..##..##..##..\n" +
            "###...###...###...###...###...###...###.\n" +
            "####....####....####....####....####....\n" +
            "#####.....#####.....#####.....#####.....\n" +
            "######......######......######......####\n" +
            "#######.......#######.......#######.....";

        // Act
        var result = Day10.Part2(input);

        // Assert
        result.Should().Be(expected);

        // Output
        _testOutputHelper.WriteLine(result);
    }

    [Theory]
    [MemberData(nameof(Part2RealData))]
    [Description("What eight capital letters appear on your CRT?")]
    public void Part2_ShouldWriteToOutputRealResult(AocInput input)
    {
        // Arrange
        const string expected =
            "####.#..#.###..###..####.####..##..#....\n" +
            "...#.#..#.#..#.#..#.#....#....#..#.#....\n" +
            "..#..#..#.#..#.#..#.###..###..#....#....\n" +
            ".#...#..#.###..###..#....#....#....#....\n" +
            "#....#..#.#....#.#..#....#....#..#.#....\n" +
            "####..##..#....#..#.#....####..##..####.";

        // Act
        var result = Day10.Part2(input);

        // Assert
        result.Should().Be(expected);

        // Output
        _testOutputHelper.WriteLine(result);
    }
}
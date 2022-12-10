using System.ComponentModel;
using AdventOfCodeLib;
using Xunit.Abstractions;
using static AdventOfCodeLib.TextFileReaderService;

namespace AdventOfCode2022.Tests.Unit;

[AocPuzzle(2022, 10, "Cathode-Ray Tube")]
public class Day10Tests
{
    private readonly Day10 _sut;
    private readonly ITestOutputHelper _testOutputHelper;

    public Day10Tests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;

        // Arrange
        _sut = new Day10();
    }

    private static IEnumerable<string> TestData => FetchFile(@"..\..\..\Data\Day10_Test.txt", ReadAsEnumerable);
    private static IEnumerable<string> RealData => FetchFile(@"..\..\..\Data\Day10.txt", ReadAsEnumerable);

    public static TheoryData<IEnumerable<string>, int> Part1Data => new()
    {
        { TestData, 13140 },
        { RealData, 13740 }
    };

    public static TheoryData<IEnumerable<string>> Part2TestData => new()
    {
        TestData
    };

    public static TheoryData<IEnumerable<string>> Part2RealData => new()
    {
        RealData
    };


    [Theory]
    [MemberData(nameof(Part1Data))]
    [Description("What is the sum of these six signal strengths?")]
    public void Part1_ShouldReturnInteger(IEnumerable<string> values, int expected)
    {
        // Act
        var result = _sut.Part1(values);

        // Assert
        result.Should().Be(expected);
    }

    [Theory]
    [MemberData(nameof(Part2TestData))]
    [Description("What eight capital letters appear on your CRT?")]
    public void Part2_ShouldWriteToOutputTestResult(IEnumerable<string> values)
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
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
        
        // Output
        _testOutputHelper.WriteLine(result);
    }

    [Theory]
    [MemberData(nameof(Part2RealData))]
    [Description("What eight capital letters appear on your CRT?")]
    public void Part2_ShouldWriteToOutputRealResult(IEnumerable<string> values)
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
        var result = _sut.Part2(values);

        // Assert
        result.Should().Be(expected);
        
        // Output
        _testOutputHelper.WriteLine(result);
    }
}
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using Serilog;
using TextCopy;

namespace AdventOfCodeCli;

public sealed partial class Application
{
    private readonly IClipboard _clipboard;
    private readonly IConfiguration _config;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger _logger;

    public Application(IConfiguration config, ILogger logger, IHttpClientFactory httpClientFactory,
        IClipboard clipboard)
    {
        _config = config;
        _logger = logger;
        _httpClientFactory = httpClientFactory;
        _clipboard = clipboard;
    }

    public async Task RunAsync(string[] args)
    {
        var aocYear = args[0];
        var aocDay = args[1];
        var client = _httpClientFactory.CreateClient("AoC");

        var input = await client.GetStringAsync($"{aocYear}/day/{aocDay}/input");
        if (input is "Error")
        {
            _logger.Fatal("Error while fetching input data");
            return;
        }

        // Get AoC title
        var instructions = await client.GetStringAsync($"{aocYear}/day/{aocDay}");
        var title = AocDayTitleRegex().Match(instructions).Groups[2].Value;

        _logger.Information("Current Directory: {Path}", Directory.GetCurrentDirectory());

        var day = PrependLeadingZero(int.Parse(aocDay));

        // Create Day
        var srcDirectory = _config["Directories:src"]!;
        var aocDirectory = CreateDirectory(Path.GetFullPath($@"{srcDirectory}\{aocYear}\AdventOfCode{aocYear}"));
        var aocDayFileName = CreateAocDayFileName(day);
        var acoFilePath = Path.Combine(aocDirectory.FullName, aocDayFileName);
        await CreateAocDayClassFile(acoFilePath, title, aocYear, aocDay, day);

        // Create Day Tests
        var testsDirectory = _config["Directories:tests"]!;
        var aocTestDirectory = CreateDirectory(Path.GetFullPath(
            $@"{testsDirectory}\{aocYear}\AdventOfCode{aocYear}.Tests.Unit"));
        var aocTestFileName = CreateAocTestFileName(day);
        var acoTestFilePath = Path.Combine(aocTestDirectory.FullName, aocTestFileName);
        await CreateAocTestClassFile(acoTestFilePath, title, aocYear, aocDay, day);

        // Create Input files
        // Real input
        var (realInputFileName, testInputFileName) = CreateTestFileNames(day);
        var aocDataDirectory = CreateDirectory(Path.GetFullPath(
            $@"{testsDirectory}\{aocYear}\AdventOfCode{aocYear}.Tests.Unit\Data"));

        var realInputFilePath = Path.Combine(aocDataDirectory.FullName, realInputFileName);
        await CreateRealInputFile(realInputFilePath, input);

        // Test input
        var testInputFilePath = Path.Combine(aocDataDirectory.FullName, testInputFileName);
        await CreateTestInputFile(testInputFilePath);
    }

    private async Task CreateAocDayClassFile(string acoFilePath, string title, string aocYear, string aocDay,
        string day)
    {
        if (File.Exists(acoFilePath))
        {
            _logger.Information("File already exists: {File}", acoFilePath);
            return;
        }

        _logger.Information("File was created: {File}", acoFilePath);
        await CreateAocTemplate(acoFilePath, title, aocYear, aocDay, day);
    }

    private async Task CreateAocTestClassFile(string acoTestFilePath, string title, string aocYear, string aocDay,
        string day)
    {
        if (File.Exists(acoTestFilePath))
        {
            _logger.Information("File already exists: {File}", acoTestFilePath);
            return;
        }

        _logger.Information("File was created: {File}", acoTestFilePath);
        await CreateAocTestTemplate(acoTestFilePath, title, aocYear, aocDay, day);
    }

    private async Task CreateRealInputFile(string realInputFilePath, string input)
    {
        if (File.Exists(realInputFilePath))
        {
            _logger.Information("File already exists: {File}", realInputFilePath);
            return;
        }

        _logger.Information("File was created: {File}", realInputFilePath);
        await File.WriteAllTextAsync(realInputFilePath, input);
    }

    private async Task CreateTestInputFile(string testInputFilePath)
    {
        if (File.Exists(testInputFilePath))
        {
            _logger.Information("File already exists: {File}", testInputFilePath);
            return;
        }

        _logger.Information("Awaiting copy from clipboard...");
        await _clipboard.SetTextAsync("");
        string? clipboard;
        do
        {
            clipboard = await _clipboard.GetTextAsync();
        } while (clipboard is null or "");

        _logger.Information("File was created: {File}", testInputFilePath);
        await File.WriteAllTextAsync(testInputFilePath, clipboard);
    }

    private DirectoryInfo CreateDirectory(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            _logger.Information("Directory already exists: {Directory}", directoryPath);
            return new DirectoryInfo(directoryPath);
        }

        _logger.Information("Directory does not exist: {Directory}", directoryPath);
        return Directory.CreateDirectory(directoryPath);
    }

    private static async Task CreateAocTemplate(string acoFilePath, string title, string aocYear, string aocDay,
        string day)
    {
        var aocTemplate = $$"""
                            using AdventOfCodeLib;

                            namespace AdventOfCode{{aocYear}};

                            [AocPuzzle({{aocYear}}, {{aocDay}}, "{{title}}")]
                            public sealed class Day{{day}} : IAocDay<int>
                            {
                                public static int Part1(AocInput input) => 0;
                            
                                public static int Part2(AocInput input) => 0;
                            }
                            """;

        await File.WriteAllTextAsync(acoFilePath, aocTemplate);
    }

    private static async Task CreateAocTestTemplate(string realInputFilePath, string title, string aocYear,
        string aocDay, string day)
    {
        var aocTestTemplate = $$"""
                                using System.ComponentModel;
                                using AdventOfCodeLib;
                                using FluentAssertions;
                                using static AdventOfCodeLib.AocFileReaderService;

                                namespace AdventOfCode{{aocYear}}.Tests.Unit;

                                [AocPuzzle({{aocYear}}, {{aocDay}}, "{{title}}")]
                                public sealed class Day{{day}}Tests
                                {
                                    private const string Day = nameof(Day{{day}});
                                    private const string TestData = @$"..\..\..\Data\{Day}_Test.txt";
                                    private const string RealData = @$"..\..\..\Data\{Day}.txt";
                                    private readonly Day{{day}} _sut = new();
                                
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
                                    [Description("")]
                                    public void Part1_ShouldReturnInteger_WhenSample(AocInput input, int expected)
                                    {
                                        // Act
                                        var result = Day{{day}}.Part1(input);
                                
                                        // Assert
                                        result.Should().Be(expected);
                                    }
                                    
                                    [Theory]
                                    [MemberData(nameof(Part2Data))]
                                    [Description("")]
                                    public void Part2_ShouldReturnInteger_WhenSample(AocInput input, int expected)
                                    {
                                        // Act
                                        var result = Day{{day}}.Part2(input);
                                    
                                        // Assert
                                        result.Should().Be(expected);
                                    }
                                }
                                """;

        await File.WriteAllTextAsync(realInputFilePath, aocTestTemplate);
    }

    private static string PrependLeadingZero(int day) => day < 10 ? $"0{day}" : $"{day}";

    private static string CreateAocDayFileName(string day) => @$"Day{day}.cs";

    private static string CreateAocTestFileName(string day) => @$"Day{day}Tests.cs";

    private static (string, string) CreateTestFileNames(string day) => ($"Day{day}.txt", $"Day{day}_Test.txt");

    [GeneratedRegex(@"<h2>--- Day (\d*): (.*) ---</h2>")]
    private static partial Regex AocDayTitleRegex();
}
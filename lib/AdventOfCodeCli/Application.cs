using System.Text.RegularExpressions;
using AdventOfCodeLib;
using Microsoft.Extensions.Configuration;
using Serilog;
using TextCopy;

namespace AdventOfCodeCli;

public sealed partial class Application(
    IConfiguration config,
    ILogger logger,
    IHttpClientFactory httpClientFactory,
    IClipboard clipboard)
{
    public async Task RunAsync(string[] args)
    {
        var aocYear = args[0];
        var aocDay = args[1];
        var client = httpClientFactory.CreateClient("AoC");

        var input = await client.GetStringAsync($"{aocYear}/day/{aocDay}/input");
        if (input is "Error")
        {
            logger.Fatal("Error while fetching input data");
            return;
        }

        // Get AoC title
        var instructions = await client.GetStringAsync($"{aocYear}/day/{aocDay}");
        var title = AocDayTitleRegex().Match(instructions).Groups[2].Value;
        var question = AocPart1QuestionRegex().Match(instructions).Groups[1].Value;

        logger.Information("Current Directory: {Path}", Directory.GetCurrentDirectory());

        var day = aocDay
            .Pipe(int.Parse)
            .Pipe(PrependLeadingZero);

        // Create Aoc Day X file
        var srcDirectory = config["Directories:src"]!;
        var aocFilePath = $@"{srcDirectory}\{aocYear}\AdventOfCode{aocYear}"
            .Pipe(Path.GetFullPath)
            .Pipe(CreateDirectory)
            .Pipe(aocDir => Path.Combine(aocDir.FullName, CreateAocDayFileName(day))); 

        await CreateAocDayClassFileAsync(aocFilePath, title, aocYear, aocDay, day);

        // Create Aoc Day X test file
        var testsDirectory = config["Directories:tests"]!;
        var acoTestFilePath = $@"{testsDirectory}\{aocYear}\AdventOfCode{aocYear}.Tests.Unit"
            .Pipe(Path.GetFullPath)
            .Pipe(CreateDirectory)
            .Pipe(aocTestDir => Path.Combine(aocTestDir.FullName, CreateAocTestFileName(day)));
        
        await CreateAocTestClassFileAsync(acoTestFilePath, title, question, aocYear, aocDay, day);
        
        // Create Real input file
        var (realInputFileName, testInputFileName) = CreateTestFileNames(day);
        var aocDataDirectory = $@"{testsDirectory}\{aocYear}\AdventOfCode{aocYear}.Tests.Unit\Data"
            .Pipe(Path.GetFullPath)
            .Pipe(CreateDirectory);

        var realInputFilePath = Path.Combine(aocDataDirectory.FullName, realInputFileName);
        await CreateRealInputFileAsync(realInputFilePath, input);

        // Create Test input file
        var testInputFilePath = Path.Combine(aocDataDirectory.FullName, testInputFileName);
        await CreateTestInputFileAsync(testInputFilePath);
    }

    private async Task CreateAocDayClassFileAsync(string acoFilePath, string title, string aocYear, 
        string aocDay, string day)
    {
        if (File.Exists(acoFilePath))
        {
            logger.Information("File already exists: {File}", acoFilePath);
            return;
        }

        logger.Information("File was created: {File}", acoFilePath);
        await CreateAocTemplateAsync(acoFilePath, title, aocYear, aocDay, day);
    }

    private async Task CreateAocTestClassFileAsync(string acoTestFilePath, string title, string question, 
        string aocYear, string aocDay, string day)
    {
        if (File.Exists(acoTestFilePath))
        {
            logger.Information("File already exists: {File}", acoTestFilePath);
            return;
        }

        logger.Information("File was created: {File}", acoTestFilePath);
        await CreateAocTestTemplateAsync(acoTestFilePath, title, question, aocYear, aocDay, day);
    }

    private async Task CreateRealInputFileAsync(string realInputFilePath, string input)
    {
        if (File.Exists(realInputFilePath))
        {
            logger.Information("File already exists: {File}", realInputFilePath);
            return;
        }

        logger.Information("File was created: {File}", realInputFilePath);
        await File.WriteAllTextAsync(realInputFilePath, input);
    }

    private async Task CreateTestInputFileAsync(string testInputFilePath)
    {
        if (File.Exists(testInputFilePath))
        {
            logger.Information("File already exists: {File}", testInputFilePath);
            return;
        }

        logger.Information("Awaiting copy from clipboard...");
        await clipboard.SetTextAsync("");
        string? text;
        do
        {
            text = await clipboard.GetTextAsync();
        } while (string.IsNullOrEmpty(text));

        logger.Information("File was created: {File}", testInputFilePath);
        await File.WriteAllTextAsync(testInputFilePath, text);
    }

    private DirectoryInfo CreateDirectory(string directoryPath)
    {
        if (Directory.Exists(directoryPath))
        {
            logger.Information("Directory already exists: {Directory}", directoryPath);
            return new DirectoryInfo(directoryPath);
        }

        logger.Information("Directory does not exist: {Directory}", directoryPath);
        return Directory.CreateDirectory(directoryPath);
    }

    private static async Task CreateAocTemplateAsync(string acoFilePath, string title, string aocYear, string aocDay,
        string day)
    {
        var aocTemplate =
            $$"""
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

    private static async Task CreateAocTestTemplateAsync(string realInputFilePath, string title, string question,
        string aocYear, string aocDay, string day)
    {
        var aocTestTemplate =
            $$"""
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
                  [Description("{{question}}")]
                  public void Part1_ShouldReturnInteger_WhenSample(AocInput input, int expected)
                  {
                      // Act
                      var result = Day{{day}}.Part1(input);
              
                      // Assert
                      result.Should().Be(expected);
                  }
                  
                  [Theory]
                  [MemberData(nameof(Part2Data))]
                  [Description("<insert here>")]
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

    private static string CreateAocDayFileName(string day) => $"Day{day}.cs";

    private static string CreateAocTestFileName(string day) => $"Day{day}Tests.cs";

    private static (string, string) CreateTestFileNames(string day) => ($"Day{day}.txt", $"Day{day}_Test.txt");

    [GeneratedRegex(@"<h2>--- Day (\d*): (.*) ---</h2>")]
    private static partial Regex AocDayTitleRegex();
    
    [GeneratedRegex(@"<em>(.*\?)</em>")]
    private static partial Regex AocPart1QuestionRegex();
}
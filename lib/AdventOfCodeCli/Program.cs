using Microsoft.Extensions.Configuration;
using Serilog;
using TextCopy;

var (year, day) = ReadArgs(args);

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddUserSecrets<Program>()
    .Build();

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();    

var url = $"https://adventofcode.com/{year}/day/{day}/input";
using var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("Cookie", $"session={config["Session"]}");

var input = await GetAocInput(httpClient, url);

if (input is "Error")
{
    Log.Logger.Fatal("Error while fetching input data");
    return;
}

Log.Logger.Information("Path: {Path}", Directory.GetCurrentDirectory());
var exportDirectory = $@"..\..\tests\{year}\AdventOfCode{year}.Tests.Unit\Data";
var fullPath = Path.GetFullPath(exportDirectory);
var dayStr = TryPrependZero(int.Parse(day));
var (fileName, testName) = CreateFileNames(dayStr);

if (!Directory.Exists(exportDirectory))
{
    Log.Logger.Information("Directory does not exist");
    Directory.CreateDirectory(exportDirectory);
}

var filePath = Path.Combine(fullPath, fileName);
if (File.Exists(filePath) is false)
{
    Log.Logger.Information("File {FileName} does not exist", fileName);
    await File.WriteAllTextAsync(filePath, input);
    Log.Logger.Information("File {FileName} was written to {FilePath}", fileName, filePath);
}
else
{
    Log.Logger.Information("File {FileName} exists", fileName);
}

var testPath = Path.Combine(fullPath, testName);
if (File.Exists(testPath) is false)
{
    Log.Logger.Information("File {TestName} does not exist", testName);
    Log.Logger.Information("Awaiting copy from clipboard...");
    await ClipboardService.SetTextAsync("");
    string? clipboard;
    do
    {
        clipboard = await ClipboardService.GetTextAsync();
    } while (clipboard is null or "");

    await File.WriteAllTextAsync(testPath, clipboard);
    Log.Logger.Information("File {TestName} was written to {TestPath}", testName, testPath);
}
else
{
    Log.Logger.Information("File {TestName} exists", testName);
}

static async Task<string> GetAocInput(HttpClient httpClient, string url)
{
    return await httpClient.GetStringAsync(url);
}

static (string, string) ReadArgs(IReadOnlyList<string> args)
{
    if (args.Count is not 0) return (args[0], args[1]);

    Console.Write("Year: ");
    var year = Console.ReadLine()!;
    Console.Write(" Day: ");
    var day = Console.ReadLine()!;
    return (year, day);
}

static string TryPrependZero(int value) => value < 10 ? $"0{value}" : $"{value}";

static (string, string) CreateFileNames(string value)
{
    var fileName = @$"Day{value}.txt";
    var testName = @$"Day{value}_Test.txt";
    return (fileName, testName);
}
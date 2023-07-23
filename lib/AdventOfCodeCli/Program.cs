using Microsoft.Extensions.Configuration;
using TextCopy;

var (year, day) = ReadArgs(args);

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var url = $"https://adventofcode.com/{year}/day/{day}/input";
using var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Add("Cookie", $"session={config["Session"]}");

var input = await GetInput(httpClient, url);

if (input is "Error")
{
    Console.WriteLine("Error while fetching input data");
    return;
}

var directoryTo = $@"..\..\..\..\..\tests\{year}\AdventOfCode{year}.Tests.Unit\Data\";
var fullPath = Path.GetFullPath(directoryTo);
var dayStr = int.Parse(day) < 10 ? $"0{day}" : $"{day}";
var fileName = @$"Day{dayStr}.txt";
var fileNameTest = @$"Day{dayStr}_Test.txt";

if (!Directory.Exists(directoryTo))
{
    Console.WriteLine("Directory does not exist");
    Directory.CreateDirectory(directoryTo);
}

if (!File.Exists(fullPath + fileName))
{
    Console.WriteLine($"File {fileName} does not exist");
    await File.WriteAllTextAsync(fullPath + fileName, input);
    Console.WriteLine($"File {fileName} was written to {fullPath}");
}
else
    Console.WriteLine($"File {fileName} exists in {fullPath}");

if (!File.Exists(fullPath + fileNameTest))
{
    Console.WriteLine($"File {fileNameTest} does not exist");
    Console.WriteLine("Awaiting copy from clipboard...");
    await ClipboardService.SetTextAsync("");
    string? clipboard;
    do
    {
        clipboard = await ClipboardService.GetTextAsync();
    } while (clipboard is null or "");

    await File.WriteAllTextAsync(fullPath + fileNameTest, clipboard);
    Console.WriteLine($"File {fileNameTest} was written to {fullPath}");
}
else
    Console.WriteLine($"File {fileNameTest} exists in {fullPath}");

static async Task<string> GetInput(HttpClient httpClient, string url)
{
    var response = await httpClient.GetAsync(url);
    if (response.IsSuccessStatusCode) return await response.Content.ReadAsStringAsync();

    return "Error";
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
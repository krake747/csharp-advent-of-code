using Microsoft.Extensions.Configuration;

namespace AdventOfCodeCli;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();
        
        var session = config["Session"]; 
        var (year, day) = ReadArgs(args);
        
        using var httpClient = new HttpClient();
        var url = $"https://adventofcode.com/{year}/day/{day}/input";
        httpClient.DefaultRequestHeaders.Add("Cookie", $"session={session}");
        
        var input = await GetInput(httpClient, url);

        if (input == "Error")
        {
            Console.WriteLine("Error while fetching input data");
            return;
        }
        
        var dayStr = int.Parse(day) < 10 ? $"0{day}" : $"{day}";
        var directoryTo = $@"..\..\..\..\..\tests\{year}\AdventOfCode{year}.Tests.Unit\Data\";
        var fullPath  = Path.GetFullPath(directoryTo);
        var fileName = @$"Day{dayStr}.txt";

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
        {
            Console.WriteLine($"File {fileName} exists in {fullPath}");
        }
    }

    private static async Task<string> GetInput(HttpClient httpClient, string url)
    {
        var response = await httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadAsStringAsync();
        }

        return "Error";
    }

    private static (string, string) ReadArgs(IReadOnlyList<string> args)
    {
        if (args.Count != 0)
            return (args[0], args[1]);
        
        Console.Write("Year: ");
        var year = Console.ReadLine()!;
        Console.Write(" Day: ");
        var day = Console.ReadLine()!;
        return (year, day);
    }
}
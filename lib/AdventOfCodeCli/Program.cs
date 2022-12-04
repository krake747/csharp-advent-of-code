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

        var dayStr = int.Parse(day) < 10 ? $"0{day}" : $"{day}";
        var directoryTo = $@"..\..\..\..\..\{year}\tests\AdventOfCode{year}.Tests.Unit\Data\";
        var fullPath  = Path.GetFullPath(directoryTo);
        var fileName = @$"Day{dayStr}.txt";

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

    private static (string Year, string Day) ReadArgs(IReadOnlyList<string> args)
    {
        return args.Count != 0
            ? (args[0], args[1])
            : ("2022", "4");
    }
}
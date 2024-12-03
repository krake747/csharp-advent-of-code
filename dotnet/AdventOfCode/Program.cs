using AdventOfCode.Lib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Spectre.Console;
using TextCopy;
using Generator = AdventOfCode.Generator.Application;
using Runner = AdventOfCode.Runner.Application;

var console = AnsiConsole.Console;

if (args.Length is 0)
{
    args = new string[2];
    console.Write("Year: ");
    args[0] = Console.ReadLine()!;
    console.Write(" Day: ");
    args[1] = Console.ReadLine()!;
}

// args = new string[2] { "2015", "7" };

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateLogger();

Log.Logger = logger;

var services = new ServiceCollection();
services.AddSingleton<IConfiguration>(config);
services.AddSingleton<ILogger>(logger);
services.AddKeyedSingleton<Generator>("generator");
services.AddKeyedSingleton<Runner>("runner");
services.InjectClipboard();
services.AddHttpClient<HttpClient>("AoC", x =>
{
    x.BaseAddress = new Uri("https://adventofcode.com/");
    x.DefaultRequestHeaders.Add("Cookie", $"session={config["Session"]}");
});

var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetRequiredKeyedService<Generator>("generator");
var runner = serviceProvider.GetRequiredKeyedService<Runner>("runner");

try
{
    await app.RunAsync(args);
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unexpected error");
}
finally
{
    await Log.CloseAndFlushAsync();
}


var aocDays = AocDayFinder.FindAocSolvers();

foreach (var aocDay in aocDays.Keys)
{
    AnsiConsole.WriteLine(aocDays[aocDay].ToString());
    AocFileReader.ReadInput("");

    var solver = Activator.CreateInstance(aocDays[aocDay]) as IAocSolver;
    var partOne = solver?.PartOne(new AocInput("", [], []));
    var partTwo = solver?.PartOne(new AocInput("", [], []));
}
using AdventOfCodeCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using TextCopy;

// if (args.Length is 0)
// {
//     args = new string[2];
//     Console.Write("Year: ");
//     args[0] = Console.ReadLine()!;
//     Console.Write(" Day: ");
//     args[1] = Console.ReadLine()!;
// }

args = new string[2] { "2015", "7" };

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
services.AddSingleton<Application>();
services.InjectClipboard();
services.AddHttpClient<HttpClient>("AoC", x =>
{
    x.BaseAddress = new Uri("https://adventofcode.com/");
    x.DefaultRequestHeaders.Add("Cookie", $"session={config["Session"]}");
});

var serviceProvider = services.BuildServiceProvider();

var app = serviceProvider.GetRequiredService<Application>();

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
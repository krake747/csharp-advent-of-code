using System.Text;

namespace AdventOfCodeLib;

public class TextFileParserService : IFileParserService
{
    private readonly string _inputFolder = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Inputs\");

    public IEnumerable<string> Fetch(string path)
    {
        var fileLocation = _inputFolder + path;
        return Read(fileLocation);
    }

    private static IEnumerable<string> Read(string path)
    {
        return File.ReadAllLines(path, Encoding.UTF8)
            .SelectMany(x => x.Split(new[] { '\t' }));
    }
}
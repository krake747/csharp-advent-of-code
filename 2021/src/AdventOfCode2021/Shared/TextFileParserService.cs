using System.Text;

namespace AdventOfCode2021.Shared;

public class TextFileParserService : IFileParserService
{
    private readonly string _inputFolder = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\Inputs\");

    public IEnumerable<string> Fetch(string path)
    {
        var fileLocation = _inputFolder + path;
        return Read(fileLocation);
    }

    internal IEnumerable<string> Read(string path) =>
        File.ReadAllLines(path, Encoding.UTF8)
            .SelectMany(x => x.Split(new char[] { '\t' }));
}

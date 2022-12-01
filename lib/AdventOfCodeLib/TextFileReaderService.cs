using System.Text;

namespace AdventOfCodeLib;

public static class TextFileReaderService
{
    public static IEnumerable<string> Fetch(string pathToFolder ,string pathToFile)
    {
        var fileLocation = Path.Combine(Directory.GetCurrentDirectory(), pathToFolder) + pathToFile;
        return Read(fileLocation);
    }

    private static IEnumerable<string> Read(string path)
    {
        return File.ReadAllLines(path, Encoding.UTF8)
            .Select(x => x);
    }
}
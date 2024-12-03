using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode.Lib;

public static partial class AocFileReader
{
    public static AocInput ReadInput(string from) => new(ReadAsString(from), ReadAsStream(from), ReadAsLines(from));

    private static string ReadAsString(string from) => FetchFile(from, TextReader);

    private static IEnumerable<string> ReadAsStream(string from) => FetchFile(from, StreamReader);

    private static string[] ReadAsLines(string from) => FetchFile(from, LinesReader);

    private static T FetchFile<T>(string from, Func<string, T> reader) =>
        reader(Path.Combine(Directory.GetCurrentDirectory(), from));

    private static IEnumerable<string> StreamReader(string path) => File.ReadLines(path, Encoding.UTF8);

    private static string[] LinesReader(string path) => File.ReadAllLines(path, Encoding.UTF8);

    private static string TextReader(string path)
    {
        var result = File.ReadAllText(path, Encoding.UTF8);
        return (WindowsLineEndingRegex().IsMatch(result)
            ? WindowsLineEndingRegex().Replace(result, "\n")
            : result).TrimEnd();
    }

    [GeneratedRegex("\r\n")]
    private static partial Regex WindowsLineEndingRegex();
}
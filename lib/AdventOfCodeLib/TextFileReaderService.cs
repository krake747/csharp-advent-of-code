using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCodeLib;

public static partial class AocFileReaderService
{
    public static AocInput ReadInput(string from) => new()
    {
        Text = ReadAsString(from),
        Lines = ReadAsStream(from)
    };

    private static string ReadAsString(string from) => FetchFile(from, TextReader);

    private static IEnumerable<string> ReadAsStream(string from) => FetchFile(from, StreamReader);

    private static T FetchFile<T>(string from, Func<string, T> reader) =>
        reader(Path.Combine(Directory.GetCurrentDirectory(), from));

    private static IEnumerable<string> StreamReader(string path) => File.ReadLines(path, Encoding.UTF8);

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
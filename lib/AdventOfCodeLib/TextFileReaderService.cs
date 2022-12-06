using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCodeLib;

public static class TextFileReaderService
{
    public static T FetchFile<T>(string from, Func<string,T> reader)
    {
        return reader(Path.Combine(Directory.GetCurrentDirectory(), from));
    }

    public static IEnumerable<string> ReadAsEnumerable(string path)
    {
        return File.ReadLines(path, Encoding.UTF8);
    }
    
    public static string[] ReadAsArray(string path)
    {
        return File.ReadAllLines(path, Encoding.UTF8);
    }
    
    public static string ReadAsString(string path)
    {
        var result = File.ReadAllText(path, Encoding.UTF8);
        return (Regex.Match(result, "\r\n").Success 
            ? Regex.Replace(result, "\r\n", "\n") 
            : result).TrimEnd();
    }
}
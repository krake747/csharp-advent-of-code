using System.Collections.Immutable;
using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day02 : IDayEnumerable
{
    private readonly Dictionary<string, Shape> _decrypter = new()
    {
        { "A", Shape.Rock },
        { "B", Shape.Paper },
        { "C", Shape.Scissors },
        { "X", Shape.Rock },
        { "Y", Shape.Paper },
        { "Z", Shape.Scissors },
    };

    public int Part1(IEnumerable<string> input)
    {
        return input.Select(code => Decrypt(_decrypter, code))
            .Sum(Score);
    }
    
    public int Part2(IEnumerable<string> input)
    {
        return 1;
    }
    
    
    private static (Shape, Shape) Decrypt(Dictionary<string, Shape> decrypter, string code)
    {
        if (decrypter is null) 
            throw new ArgumentNullException(nameof(decrypter));
        
        var split = code.Split(" ");
        return (decrypter[split[0]], decrypter[split[1]]);

    }

    private static int Score((Shape, Shape) shapes)
    {
        var (left, right) = shapes;
        return (int)right + (left, right) switch
        {
            (Shape.Rock, Shape.Paper) => (int)Outcome.Win,
            (Shape.Paper, Shape.Scissors) => (int)Outcome.Win,
            (Shape.Scissors, Shape.Rock) => (int)Outcome.Win,
            (Shape.Rock, Shape.Scissors) => (int)Outcome.Lose,
            (Shape.Paper, Shape.Rock) => (int)Outcome.Lose,
            (Shape.Scissors, Shape.Paper) => (int)Outcome.Lose,
            (_, _) => (int)Outcome.Draw,
        };
    }
}

public enum Shape
{
    Rock = 1,
    Paper,
    Scissors,
}

public enum Outcome
{
    Lose = 0,
    Draw = 3,
    Win = 6,
}
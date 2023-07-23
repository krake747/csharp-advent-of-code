using AdventOfCodeLib.Interfaces;

namespace AdventOfCode2022;

public class Day02 : IDay<IEnumerable<string>, int>
{
    public int Part1(IEnumerable<string> input)
    {
        return input.Select(code => Decrypt(code, ParseShape))
            .Sum(Score);
    }

    public int Part2(IEnumerable<string> input)
    {
        return input.Select(code => Decrypt(code, ParseShape, ParseOutcome, DesiredOutcome))
            .Sum(Score);
    }

    private static (T, T) Decrypt<T>(string code, Func<char, T> decrypter) => (decrypter(code[0]), decrypter(code[^1]));

    private static (TL, TR) Decrypt<TL, TO, TR>(string code, Func<char, TL> leftParser, Func<char, TO> rightParser,
        Func<TL, TO, TR> rightDecrypter)
    {
        var leftShape = leftParser(code[0]);
        var rightOutcome = rightParser(code[^1]);
        return (leftShape, rightDecrypter(leftShape, rightOutcome));
    }

    private static Shape ParseShape(char c)
    {
        return c switch
        {
            'A' or 'X' => Shape.Rock,
            'B' or 'Y' => Shape.Paper,
            'C' or 'Z' => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(c), "Matching pattern is not defined")
        };
    }

    private static Result ParseOutcome(char c)
    {
        return c switch
        {
            'X' => Result.Lose,
            'Y' => Result.Draw,
            'Z' => Result.Win,
            _ => throw new ArgumentOutOfRangeException(nameof(c), "Matching pattern is not defined")
        };
    }

    private static Shape DesiredOutcome(Shape leftShape, Result rightOutcome)
    {
        var losesTo = new Dictionary<Shape, Shape>
        {
            { Shape.Paper, Shape.Rock },
            { Shape.Rock, Shape.Scissors },
            { Shape.Scissors, Shape.Paper }
        };

        return rightOutcome switch
        {
            Result.Draw => leftShape,
            Result.Lose => losesTo[leftShape],
            _ => losesTo.First(shape => shape.Value == leftShape).Key
        };
    }

    private static int Score((Shape, Shape) shapes)
    {
        var (left, right) = shapes;
        return left == right
            ? (int)right + (int)Result.Draw
            : (int)right + (left, right) switch
            {
                (Shape.Rock, Shape.Paper) => (int)Result.Win,
                (Shape.Paper, Shape.Scissors) => (int)Result.Win,
                (Shape.Scissors, Shape.Rock) => (int)Result.Win,
                (_, _) => (int)Result.Lose
            };
    }

    private enum Shape
    {
        Rock = 1,
        Paper,
        Scissors
    }

    private enum Result
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }
}
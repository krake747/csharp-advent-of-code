using AdventOfCodeLib;

namespace AdventOfCode2022;

public class Day02 : IDayEnumerable
{
    public int Part1(IEnumerable<string> input)
    {
        return input.Select(code => Decrypt(code, ShapeDecrypter))
            .Sum(Score);
    }

    public int Part2(IEnumerable<string> input)
    {
        return input.Select(code => Decrypt(code, ShapeDecrypter, DesiredOutcome, OutcomeDecrypter))
            .Sum(Score);
    }

    private static (T, T) Decrypt<T>(string code, Func<char, T> decrypter)
    {
        var span = code.AsSpan();
        return (decrypter(span[0]), decrypter(span[^1]));
    }

    private static (TL, TR) Decrypt<TL, TR, TO>(string code,
        Func<char, TL> leftDecrypter,
        Func<char, TO> outcomePredictor,
        Func<TL, TO, TR> rightDecrypter)
    {
        var span = code.AsSpan();
        var leftShape = leftDecrypter(span[0]);
        var rightOutcome = outcomePredictor(span[^1]);
        return (leftShape, rightDecrypter(leftShape, rightOutcome));
    }

    private static Shape ShapeDecrypter(char character)
    {
        return character switch
        {
            'A' or 'X' => Shape.Rock,
            'B' or 'Y' => Shape.Paper,
            'C' or 'Z' => Shape.Scissors,
            _ => throw new ArgumentOutOfRangeException(nameof(character), "Matching pattern is not defined")
        };
    }

    private static Outcome DesiredOutcome(char rightCharacter)
    {
        return rightCharacter switch
        {
            'X' => Outcome.Lose,
            'Y' => Outcome.Draw,
            'Z' => Outcome.Win,
            _ => throw new ArgumentOutOfRangeException(nameof(rightCharacter), "Matching pattern is not defined")
        };
    }

    private static Shape OutcomeDecrypter(Shape leftShape, Outcome rightOutCome)
    {
        var losesTo = new Dictionary<Shape, Shape>
        {
            { Shape.Paper, Shape.Rock },
            { Shape.Rock, Shape.Scissors },
            { Shape.Scissors, Shape.Paper }
        };

        return rightOutCome switch
        {
            Outcome.Draw => leftShape,
            Outcome.Lose => losesTo[leftShape],
            _ => losesTo.First(shape => shape.Value == leftShape).Key
        };
    }

    private static int Score((Shape, Shape) shapes)
    {
        var (left, right) = shapes;
        return left == right
            ? (int)right + (int)Outcome.Draw
            : (int)right + (left, right) switch
            {
                (Shape.Rock, Shape.Paper) => (int)Outcome.Win,
                (Shape.Paper, Shape.Scissors) => (int)Outcome.Win,
                (Shape.Scissors, Shape.Rock) => (int)Outcome.Win,
                (_, _) => (int)Outcome.Lose
            };
    }

    private enum Shape
    {
        Rock = 1,
        Paper,
        Scissors
    }

    private enum Outcome
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }
}
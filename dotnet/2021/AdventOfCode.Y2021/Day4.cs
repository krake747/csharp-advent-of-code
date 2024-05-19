using System.Text.RegularExpressions;
using AdventOfCode.Lib;

namespace AdventOfCode.Y2021;

public static class Day4
{
    public static int Part1(IEnumerable<string> input)
    {
        var bingoSystem = ProcessInput(input);
        var score = BingoScore(bingoSystem);
        return score;
    }

    public static int Part2(IEnumerable<string> input)
    {
        var bingoSystem = ProcessInput(input);
        var score = BingoScore(bingoSystem, true);
        return score;
    }

    private static BingoSystem ProcessInput(IEnumerable<string> input)
    {
        var values = input.ToList();
        var numbers = values.First().Split(',');

        var board = new List<string[]>();
        var boards = new List<string[][]>();
        foreach (var row in values.Skip(2).Append(""))
        {
            if (string.IsNullOrEmpty(row))
            {
                boards.Add(board.ToArray());
                board.Clear();
                continue;
            }

            board.Add(row.Split(' ').Where(s => s != "").ToArray());
        }

        return new BingoSystem(numbers, boards);
    }

    private static int BingoScore(BingoSystem bingoSystem, bool finalBoard = false)
    {
        var winningBoards = new Dictionary<int, WinningBoard>();
        foreach (var number in bingoSystem.Numbers)
        {
            MarkNumber(bingoSystem, number);

            winningBoards = HasBingo(bingoSystem, winningBoards);

            if (winningBoards.Count == 1 && finalBoard is false)
            {
                return CalculateBingoScore(winningBoards.Select(w => w.Value).First(), number);
            }

            if (winningBoards.Count == bingoSystem.Boards.Count && finalBoard)
            {
                return CalculateBingoScore(winningBoards.Select(w => w.Value).Last(), number);
            }
        }

        return -1;
    }

    private static void MarkNumber(BingoSystem bingoSystem, string number)
    {
        var boards = bingoSystem.Boards.ToList();
        foreach (var (board, index) in boards.Select((item, index) => (item, index)))
        {
            var markedBoard = Enumerable.Range(0, board.GetLength(0))
                .Select(r => board[r].Select(x => Regex.Replace(x, $"^{number}$", "X")).ToArray())
                .ToArray();

            bingoSystem.Boards.Remove(board);
            bingoSystem.Boards.Insert(index, markedBoard);
        }
    }

    private static Dictionary<int, WinningBoard> HasBingo(BingoSystem bingoSystem,
        Dictionary<int, WinningBoard> winningBoards)
    {
        var boards = bingoSystem.Boards.ToList();
        foreach (var (board, index) in boards.Select((item, index) => (item, index)))
        {
            var checkCols = Enumerable.Range(0, board.GetLength(0))
                .Select(c => board.GetColumn(c).All(v => v == "X"))
                .Any(c => c);

            var checkRows = Enumerable.Range(0, board.GetLength(0))
                .Select(r => board.GetRow(r).All(v => v == "X"))
                .Any(r => r);

            if ((checkCols || checkRows) && !winningBoards.Select(k => k.Key).Contains(index))
            {
                winningBoards.Add(index, new WinningBoard(board));
            }

            if (winningBoards.Count == bingoSystem.Boards.Count)
            {
                return winningBoards;
            }
        }

        return winningBoards;
    }

    private static int CalculateBingoScore(WinningBoard board, string number)
    {
        var unmarkedScore = board.Board
            .Select(r => r.Where(v => v != "X").Sum(int.Parse))
            .Sum();

        return unmarkedScore * int.Parse(number);
    }

    private sealed record BingoSystem(string[] Numbers, List<string[][]> Boards);

    private sealed record WinningBoard(string[][] Board);
}
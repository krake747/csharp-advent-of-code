from aoc.core import solve, AocInput
from itertools import islice


def rollingSum(source: list[int], window: int) -> list[int]:
    values = list(range(0, len(source) - window + 1))
    return [sum(islice(source, n, n + window)) for n in values]


def part1(input: AocInput) -> int:
    values = list(map(int, input.lines))
    return sum([1 if l > r else 0 for l, r in zip(values[1:], values)])


def part2(input: AocInput) -> int:
    values = rollingSum(list(map(int, input.lines)), 3)
    return sum([1 if l > r else 0 for l, r in zip(values[1:], values)])


def main() -> None:
    YEAR = "y2021"
    DAY = "Day01"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1)
    solve(YEAR, DAY, part2)

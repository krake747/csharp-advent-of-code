from aoc.core import solve, AocInput
from itertools import product
from functools import reduce


def part1(input: AocInput) -> int:
    numbers = list(map(int, input.lines))
    entries = product(numbers, numbers)
    return reduce(lambda a, b: a * b, next(filter(lambda e: sum(e) == 2020, entries)))


def part2(input: AocInput) -> int:
    numbers = list(map(int, input.lines))
    entries = product(numbers, numbers, numbers)
    return reduce(lambda a, b: a * b, next(filter(lambda e: sum(e) == 2020, entries)))


def main() -> None:
    YEAR = "y2020"
    DAY = "Day01"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1)
    solve(YEAR, DAY, part2)

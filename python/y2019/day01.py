from aoc.core import solve, AocInput
from functools import cache


def fuel(mass: int) -> int:
    return mass // 3 - 2


@cache
def totalFuel(mass: int) -> int:
    f = fuel(mass)
    return 0 if f < 0 else f + totalFuel(f)


def part1(input: AocInput) -> int:
    return sum(map(fuel, map(int, input.lines)))


def part2(input: AocInput) -> int:
    return sum(map(totalFuel, map(int, input.lines)))


def main() -> None:
    YEAR = "y2019"
    DAY = "Day01"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1)
    solve(YEAR, DAY, part2)

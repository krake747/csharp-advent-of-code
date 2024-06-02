from aoc.core import solve, AocInput


def part1(input: AocInput) -> int:
    return 1


def part2(input: AocInput) -> int:
    return 1


def main() -> None:
    YEAR = "y20xx"
    DAY = "Dayxx"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1)
    solve(YEAR, DAY, part2)

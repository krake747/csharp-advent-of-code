from aoc.core import solve, AocInput


def leastFuelConstantRate(crabs: list[int]) -> int:
    return min(sum(abs(c - h) for c in crabs) for h in range(0, max(crabs)))


def leastFuelVariableRate(crabs: list[int]) -> int:
    return min(sum(map(lambda n: int(n * (n + 1) / 2), [abs(c - h) for c in crabs])) for h in range(0, max(crabs)))


def part1(input: AocInput) -> int:
    return leastFuelConstantRate(list(map(int, input.text.split(","))))


def part2(input: AocInput) -> int:
    return leastFuelVariableRate(list(map(int, input.text.split(","))))


def main() -> None:
    YEAR = "y2021"
    DAY = "Day07"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1)
    solve(YEAR, DAY, part2)

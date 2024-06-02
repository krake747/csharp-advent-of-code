from aoc.core import solve, allValid, AocInput
from collections import Counter
from itertools import pairwise


def sixDigits(password: str) -> bool:
    return len(password) == 6


def increasing(password: str) -> bool:
    return not any(a > b for a, b in pairwise(password))


def potentialDouble(password: str) -> bool:
    return any(filter(lambda n: n >= 2, Counter(password).values()))


def exactDouble(password: str) -> bool:
    return any(filter(lambda n: n == 2, Counter(password).values()))


def part1(input: AocInput) -> int:
    lower, upper = input.text.split("-", 2)
    return sum(allValid(str(pw), sixDigits, increasing, potentialDouble) for pw in range(int(lower), int(upper)))


def part2(input: AocInput) -> int:
    lower, upper = input.text.split("-", 2)
    return sum(allValid(str(pw), sixDigits, increasing, exactDouble) for pw in range(int(lower), int(upper)))


def main() -> None:
    YEAR = "y2019"
    DAY = "Day04"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1, skipTest=True)
    solve(YEAR, DAY, part2, skipTest=True)

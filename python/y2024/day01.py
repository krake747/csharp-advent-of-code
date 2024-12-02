from aoc.core import solve, AocInput
from collections import Counter

def instructions(lines: list[str], col: int) -> list[int]:
    return sorted(int(line.split("   ")[col]) for line in lines)


def part1(input: AocInput) -> int:
    return sum(abs(l - r) for l, r in zip(instructions(input.lines, 0), instructions(input.lines, 1)))


def part2(input: AocInput) -> int:
    left = instructions(input.lines, 0)
    counts = Counter(instructions(input.lines, 1))
    return sum([counts[id] * id for id in left])


def main() -> None:
    YEAR = "y2024"
    DAY = "Day01"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1, 1660292)
    solve(YEAR, DAY, part2, 22776016)

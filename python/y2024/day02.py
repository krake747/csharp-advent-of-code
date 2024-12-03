from aoc.core import solve, AocInput
from dataclasses import astuple, dataclass
from typing import Iterator


@dataclass(frozen=True, slots=True)
class Pair:
    left: int
    right: int

    def __iter__(self):
        return iter(astuple(self))


def instructions(lines: list[str]) -> list[list[int]]:
    return [list(map(int, l.split(" "))) for l in lines]


def monotonicIncreasing(pairs: list[Pair]) -> bool:
    return all(1 <= (r - l) <= 3 for l, r in pairs)


def monotonicDecreasing(pairs: list[Pair]) -> bool:
    return all(1 <= (l - r) <= 3 for l, r in pairs)


def monotonic(instructions: list[int]) -> bool:
    pairs = [Pair(ls, rs) for ls, rs in zip(instructions, instructions[1:])]
    return monotonicIncreasing(pairs) or monotonicDecreasing(pairs)


def problemDampener(instructions: list[str]) -> Iterator[list[int]]:
    for i in range(len(instructions) + 1):
        yield instructions[: max(0, i - 1)] + instructions[i:]


def part1(input: AocInput) -> int:
    return sum(monotonic(i) for i in instructions(input.lines))


def part2(input: AocInput) -> int:
    return sum(any(monotonic(i) for i in problemDampener(instr)) for instr in instructions(input.lines))


def main() -> None:
    YEAR = "y2024"
    DAY = "Day02"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1, 369)
    solve(YEAR, DAY, part2, 428)

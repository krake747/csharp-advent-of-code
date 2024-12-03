from aoc.core import solve, AocInput
from dataclasses import dataclass
from functools import reduce
from typing import Match
import re


@dataclass(frozen=True, slots=True)
class State:
    enabled: bool
    total: int


def instructions(m: Match) -> int:
    return int(m.groups()[0]) * int(m.groups()[1])


def conditional_instructions(state: State, m: Match) -> State:
    match m.group(0):
        case "do()":
            return State(True, state.total)
        case "don't()":
            return State(False, state.total)
        case _ if state.enabled:
            return State(state.enabled, state.total + instructions(m))
        case _:
            return state


def part1(input: AocInput) -> int:
    return sum(instructions(m) for m in re.finditer(r"mul\((\d+),(\d+)\)", input.text))


def part2(input: AocInput) -> int:
    state = reduce(
        conditional_instructions,
        [m for m in re.finditer(r"do\(\)|don't\(\)|mul\((\d+),(\d+)\)", input.text)],
        State(True, 0),
    )
    return state.total


def main() -> None:
    YEAR = "y2024"
    DAY = "Day03"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1, 166357705, True)
    solve(YEAR, DAY, part2, 88811886, True)

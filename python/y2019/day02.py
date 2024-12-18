from aoc.core import solve, AocInput
from aoc.intcode import IntCodeMachine


def part1(input: AocInput) -> int:
    icm = IntCodeMachine.init(input.text)
    return IntCodeMachine.run(icm, noun=12, verb=2)


def part2(input: AocInput) -> int:
    icm = IntCodeMachine.init(input.text)
    return IntCodeMachine.gravityAssist(icm)


def main() -> None:
    YEAR = "y2019"
    DAY = "Day02"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1, expected=3790645, skipTest=True)
    solve(YEAR, DAY, part2, expected=6577, skipTest=True)

from aoc.core import solve, AocInput
from aoc.intcode import IntCodeMachine


def part1(input: AocInput) -> int:
    icm = IntCodeMachine.init(input.text)
    return IntCodeMachine.thermalEnvironmentSupervisionTerminal(icm, id=1)


def part2(input: AocInput) -> int:
    icm = IntCodeMachine.init(input.text)
    return IntCodeMachine.thermalEnvironmentSupervisionTerminal(icm, id=5)


def main() -> None:
    YEAR = "y2019"
    DAY = "Day05"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1, expected=9961446, skipTest=True)
    solve(YEAR, DAY, part2, expected=742621, skipTest=True)

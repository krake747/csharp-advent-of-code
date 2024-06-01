from functools import reduce
from aoc.core import pipe, solve, AocInput
from dataclasses import astuple, dataclass


@dataclass(frozen=True, slots=True)
class Coordinates:
    x: int
    y: int
    aim: int

    def __iter__(self):
        return iter(astuple(self))


def decode(coordinates: Coordinates, command: str) -> Coordinates:
    direction, units = pipe(lambda c: c.split(" ", 2), lambda p: (p[0], int(p[1])))(command)
    x, y, aim = coordinates
    match direction:
        case "forward":
            return Coordinates(x + units, y + aim * units, aim)
        case "down":
            return Coordinates(x, y, aim + units)
        case "up":
            return Coordinates(x, y, aim - units)
        case _:
            return coordinates


def part1(input: AocInput) -> int:
    x, _, aim = reduce(decode, input.lines, Coordinates(0, 0, 0))
    return x * aim


def part2(input: AocInput) -> int:
    x, y, _ = reduce(decode, input.lines, Coordinates(0, 0, 0))
    return x * y


def main() -> None:
    YEAR = "y2021"
    DAY = "Day02"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1)
    solve(YEAR, DAY, part2)

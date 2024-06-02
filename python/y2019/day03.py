from aoc.core import solve, AocInput
from dataclasses import astuple, dataclass


@dataclass(frozen=True, slots=True)
class Position:
    irow: int
    icol: int

    def __iter__(self):
        return iter(astuple(self))

    @staticmethod
    def move(position: "Position", command: str) -> "Position":
        irow, icol = position
        match command:
            case "U":
                return Position(irow - 1, icol)
            case "D":
                return Position(irow + 1, icol)
            case "R":
                return Position(irow, icol + 1)
            case "L":
                return Position(irow, icol - 1)
            case _:
                position


def traceWire(path: str) -> dict[tuple[int, int], int]:
    positions = dict()
    irow, icol = Position(0, 0)
    distance = 0
    steps = path.split(",")
    for step in steps:
        for _ in range(int(step[1:])):
            irow, icol = Position.move(Position(irow, icol), step[0])
            distance += 1
            if positions.get((irow, icol)) is None:
                positions[(irow, icol)] = distance

    return positions


def part1(input: AocInput) -> int:
    wire1 = traceWire(input.lines[0])
    wire2 = traceWire(input.lines[1])
    return min(abs(p[0]) + abs(p[1]) for p in wire1.keys() if p in wire2)


def part2(input: AocInput) -> int:
    wire1 = traceWire(input.lines[0])
    wire2 = traceWire(input.lines[1])
    return min(wire1[p] + wire2[p] for p in wire1.keys() if p in wire2)


def main() -> None:
    YEAR = "y2019"
    DAY = "Day03"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1)
    solve(YEAR, DAY, part2)

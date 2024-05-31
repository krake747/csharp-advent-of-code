from aoc.core import solve, AocInput
from dataclasses import astuple, dataclass


@dataclass(frozen=True)
class Present:
    length: int
    width: int
    height: int

    def __iter__(self):
        return iter(astuple(self))


def makePresent(values: list[str]) -> Present:
    return Present(int(values[0]), int(values[1]), int(values[2]))


def sizeUpPresents(lines: list[str]) -> list[Present]:
    return [makePresent(l.split("x")) for l in lines]


def orderWrapping(present: Present) -> int:

    def calculateSurface(l: int, w: int, h: int) -> int:
        return 2 * l * w + 2 * w * h + 2 * h * l

    def calculateAreaOfSmallestSide(l: int, w: int, h: int) -> int:
        return min(min(l * w, w * h), h * l)

    length, width, height = present
    return calculateSurface(length, width, height) + calculateAreaOfSmallestSide(length, width, height)


def orderRibbon(present: Present) -> int:

    def calculateBow(l: int, w: int, h: int) -> int:
        return l * w * h

    def calculatePerimeterOfSmallestSide(l: int, w: int, h: int) -> int:
        return min(min(2 * l + 2 * w, 2 * w + 2 * h), 2 * h + 2 * l)

    length, width, height = present
    return calculateBow(length, width, height) + calculatePerimeterOfSmallestSide(length, width, height)


def part1(input: AocInput) -> int:
    return sum(map(orderWrapping, sizeUpPresents(input.lines)))


def part2(input: AocInput) -> int:
    return sum(map(orderRibbon, sizeUpPresents(input.lines)))


def main() -> None:
    YEAR = "y2015"
    DAY = "Day02"
    print(f"Running year {YEAR.replace('y')} day {DAY.replace('Day')}")
    solve(YEAR, DAY, part1)
    solve(YEAR, DAY, part2)


if __name__ == "__main__":
    main()

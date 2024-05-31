from aoc.core import solve, AocInput
from dataclasses import astuple, dataclass
from itertools import chain


@dataclass(frozen=True)
class Point:
    x: int
    y: int

    def __iter__(self):
        return iter(astuple(self))

    @staticmethod
    def moveToNextHouse(direction: str, house: "Point"):
        x, y = house
        match direction:
            case "^":
                return Point(x, y + 1)
            case ">":
                return Point(x + 1, y)
            case "v":
                return Point(x, y - 1)
            case "<":
                return Point(x - 1, y)
            case _:
                return house


def part1(input: AocInput) -> int:
    directions = list(input.text)
    visted = [Point(0, 0)]
    for direction in directions:
        currentHouse = visted[-1]
        nextHouse = Point.moveToNextHouse(direction, currentHouse)
        visted.append(nextHouse)

    return len(set(visted))


def part2(input: AocInput) -> int:
    directions = [(i, d) for i, d in enumerate(input.text)]
    visited = [[Point(0, 0)], [Point(0, 0)]]
    for index, direction in directions:
        santa = 0 if index % 2 == 0 else 1
        currentHouse = visited[santa][-1]
        nextHouse = Point.moveToNextHouse(direction, currentHouse)
        visited[santa].append(nextHouse)

    return len(set(chain.from_iterable(visited)))


def main() -> None:
    YEAR = "y2015"
    DAY = "Day03"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1)
    solve(YEAR, DAY, part2)


if __name__ == "__main__":
    main()

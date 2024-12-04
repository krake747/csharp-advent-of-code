from aoc.core import solve, AocInput
from collections import defaultdict
from dataclasses import astuple, dataclass
from functools import partial


@dataclass(frozen=True, slots=True)
class Point:
    x: int
    y: int

    def __iter__(self):
        return iter(astuple(self))

    @staticmethod
    def North():
        return Point(0, -1)

    @staticmethod
    def NorthEast():
        return Point(1, -1)

    @staticmethod
    def East():
        return Point(1, 0)

    @staticmethod
    def SouthEast():
        return Point(1, 1)

    @staticmethod
    def South():
        return Point(0, 1)

    @staticmethod
    def SouthWest():
        return Point(-1, 1)

    @staticmethod
    def West():
        return Point(-1, 0)

    @staticmethod
    def NorthWest():
        return Point(-1, -1)

    def __add__(self, point: "Point") -> "Point":
        if isinstance(point, Point) is False:
            return NotImplemented
        return Point(self.x + point.x, self.y + point.y)

    def __mul__(self, factor: int) -> "Point":
        if isinstance(factor, int) is False:
            return NotImplemented
        return Point(self.x * factor, self.y * factor)


Map = defaultdict[Point, str]


def parse_map(lines: list[str]) -> Map:
    return defaultdict(str, {Point(x, y): c for y, l in enumerate(lines) for x, c in enumerate(l)})


def search_word(map: Map, pattern: str, p: Point, dir: Point) -> bool:
    chars = [map.get(p + dir * i) for i in range(0, len(pattern))]
    return chars == list(pattern) or chars == list(reversed(pattern))


def search_xmas(map: Map) -> list[bool]:
    directions = [Point.East(), Point.SouthEast(), Point.South(), Point.SouthWest()]
    search_map_for_xmas = partial(search_word, map, "XMAS")
    return [search_map_for_xmas(p, dir) for p in map.keys() for dir in directions]


def search_xmas_shape(map: Map) -> list[bool]:
    search_map_for_xmas_shape = partial(search_word, map, "MAS")
    return [
        search_map_for_xmas_shape(p + Point.NorthWest(), Point.SouthEast())
        and search_map_for_xmas_shape(p + Point.SouthWest(), Point.NorthEast())
        for p in map.keys()
    ]


def part1(input: AocInput) -> int:
    return sum(search_xmas(parse_map(input.lines)))


def part2(input: AocInput) -> int:
    return sum(search_xmas_shape(parse_map(input.lines)))


def main() -> None:
    YEAR = "y2024"
    DAY = "Day04"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1, 2358, True)
    solve(YEAR, DAY, part2, 1737, True)

from aoc.core import solve, AocInput


def goUpOrDownOneFloor(c: str) -> int:
    return 1 if c == '(' else - 1


def part1(input: AocInput) -> int:
    return sum(list(map(goUpOrDownOneFloor, input.text)))


def part2(input: AocInput) -> int:
    floors = []
    res = list(map(goUpOrDownOneFloor, input.text))
    for floor in res:
        lastFloorLevel = floors[-1] if len(floors) > 0 else 0
        updatedFloor = lastFloorLevel + floor
        floors.append(updatedFloor)

    return floors.index(-1) + 1


def main() -> None:
    DAY = 'Day01'
    solve(DAY, part1)
    solve(DAY, part2)


if __name__ == '__main__':
    main()

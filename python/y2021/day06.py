from aoc.core import solve, AocInput


def countLanternFishes(timers: list[int], days: int) -> int:
    fishes = dict([(f, 0) for f in range(0, 8)])
    for timer in timers:
        fishes[timer] += 1

    for _ in range(days):
        reproductionFishes = fishes[0]
        for i in range(len(fishes.keys()) - 1):
            fishes[i] = fishes[i + 1]

        fishes[6] = reproductionFishes + fishes[6]
        fishes[8] = reproductionFishes

    return sum(fishes.values())


def part1(input: AocInput) -> int:
    lanternFishes = list(map(int, input.text.split(",")))
    return countLanternFishes(lanternFishes, 80)


def part2(input: AocInput) -> int:
    lanternFishes = list(map(int, input.text.split(",")))
    return countLanternFishes(lanternFishes, 256)


def main() -> None:
    YEAR = "y2021"
    DAY = "Day06"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1)
    solve(YEAR, DAY, part2)

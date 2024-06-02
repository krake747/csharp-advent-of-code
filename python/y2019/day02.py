from aoc.core import solve, AocInput


def part1(input: AocInput) -> int:
    intCode = list(map(int, input.text.split(",")))

    intCode[1] = 12
    intCode[2] = 2

    for i in range(0, len(intCode), 4):
        op = intCode[i]
        fst = intCode[intCode[i + 1]]
        snd = intCode[intCode[i + 2]]
        if op == 99:
            print("99: ", intCode[0])
            return intCode[0]
        elif op == 1:
            intCode[intCode[i + 3]] = fst + snd
        elif op == 2:
            intCode[intCode[i + 3]] = fst * snd

    return intCode[0]


def part2(input: AocInput) -> int:
    return 1


def main() -> None:
    YEAR = "y2019"
    DAY = "Day02"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1, skipTest=True)
    solve(YEAR, DAY, part2)

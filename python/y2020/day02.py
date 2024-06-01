from os import pipe
import re
from aoc.core import compose, pipe, solve, AocInput
from dataclasses import astuple, dataclass


@dataclass(frozen=True, slots=True)
class PasswordPolicy:
    min: int
    max: int
    letter: str
    password: str

    def __iter__(self):
        return iter(astuple(self))

    @staticmethod
    def create(values: tuple[str]) -> "PasswordPolicy":
        return PasswordPolicy(int(values[0]), int(values[1]), values[2], values[3])


def parseLine(line: str) -> tuple[str]:
    parts = re.split("-| |: ", line)
    return tuple([s.strip() for s in parts])


def isPasswordPolicyValid(posswordPolicy: PasswordPolicy) -> bool:
    min, max, letter, password = posswordPolicy
    letters = len([c for c in list(password) if c == letter])
    return min <= letters <= max


def isNewPasswordPolicyValid(posswordPolicy: PasswordPolicy) -> bool:
    min, max, letter, password = posswordPolicy
    pw1 = password[min - 1]
    pw2 = password[max - 1]
    return len([c for c in [pw1, pw2] if c == letter]) == 1


def part1(input: AocInput) -> int:
    return sum(map(compose(isNewPasswordPolicyValid, PasswordPolicy.create, parseLine), input.lines))


def part2(input: AocInput) -> int:
    return sum(map(pipe(parseLine, PasswordPolicy.create, isNewPasswordPolicyValid), input.lines))


def main() -> None:
    YEAR = "y2020"
    DAY = "Day02"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1)
    solve(YEAR, DAY, part2)

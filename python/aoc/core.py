import os
from dataclasses import dataclass
from numbers import Number
from typing import Callable


@dataclass(frozen=True)
class AocInput:
    text: str
    lines: list[str]


def getAocInput(path: str) -> AocInput:
    with open(path, "r") as f:
        text = f.read()
        lines = text.splitlines()
        return AocInput(text, lines)


def logResults(part: str, test: Number, real: Number) -> None:
    print(f"Test {part.__name__}: {test}")
    print(f"Real {part.__name__}: {real}")


def solve(year: str, day: str, part: Callable[[AocInput], Number]) -> None:
    DATA_DIR = "data"
    TEST_FILE = os.path.join(year, DATA_DIR, f"{day}_Test.txt")
    REAL_FILE = os.path.join(year, DATA_DIR, f"{day}.txt")

    testInput = getAocInput(TEST_FILE)
    realInput = getAocInput(REAL_FILE)

    test, real = part(testInput), part(realInput)

    logResults(part, test, real)

from functools import reduce
import os
from dataclasses import dataclass
from numbers import Number
from typing import Callable, TypeVar, Unpack

TIn = TypeVar("TIn")
TOut = TypeVar("TOut")


@dataclass(frozen=True)
class AocInput:
    text: str
    lines: list[str]


def pipe(source: TIn, *callables: Unpack[Callable[[TIn], TOut]]) -> TOut:
    return (lambda x: reduce(lambda y, f: f(y), callables, x))(source)


def compose(*callables: Unpack[Callable[[TIn], TOut]]) -> Callable[[TIn], TOut]:
    return reduce(lambda f, g: lambda x: f(g(x)), callables, lambda x: x)


def composeLeft(*callables: Unpack[Callable[[TIn], TOut]]) -> Callable[[TIn], TOut]:
    return lambda x: reduce(lambda y, f: f(y), callables, x)


def allValid(source: TIn, *callables: Unpack[Callable[[TIn], bool]]) -> bool:
    return all(f(source) for f in callables)


def getAocInput(path: str) -> AocInput:
    with open(path, "r", encoding="utf-8-sig") as f:
        text = f.read()
        lines = text.splitlines()
        return AocInput(text, lines)


def solve(year: str, day: str, part: Callable[[AocInput], Number], skipTest: bool = False) -> None:
    def solveTest(year: str, day: str, part: Callable[[AocInput], Number]) -> None:
        DATA_DIR = "data"
        TEST_FILE = os.path.join(year, DATA_DIR, f"{day}_Test.txt")
        testInput = getAocInput(TEST_FILE)
        test = part(testInput)
        print(f"Test {part.__name__}: {test}")

    def solveReal(year: str, day: str, part: Callable[[AocInput], Number]) -> None:
        DATA_DIR = "data"
        REAL_FILE = os.path.join(year, DATA_DIR, f"{day}.txt")
        realInput = getAocInput(REAL_FILE)
        real = part(realInput)
        print(f"Real {part.__name__}: {real}")

    if skipTest:
        solveReal(year, day, part)
        return

    solveTest(year, day, part)
    solveReal(year, day, part)

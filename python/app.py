import argparse
from importlib import import_module
import tomllib
from typing import Any, Callable
from pprint import pprint


def loadConfig() -> dict[str, Any]:
    with open("config.toml", "rb") as f:
        config = tomllib.load(f)
        return config


def puzzleSolver(key: str) -> Callable[[], None] | None:
    try:
        return getattr(import_module(key), "main") or None
    except ModuleNotFoundError:
        return None


def prependZero(d: int) -> str:
    return f"0{d}" if d < 10 else f"{d}"


def main(args) -> None:
    if args.year is None or args.day is None:
        print("Requires year and day. Run -h for help")
        return None

    key = f"y{args.year}.day{prependZero(args.day)}"
    solver = puzzleSolver(key)
    if solver is None:
        print(f"{key} not found")
        return None

    solver()


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="Advent of Code Puzzle Solver")
    parser.add_argument("-y", "--year", type=int, help="AOC Year")
    parser.add_argument("-d", "--day", type=int, help="AOC Day")
    args = parser.parse_args()

    pprint(loadConfig(), sort_dicts=False)

    main(args)

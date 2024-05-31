import argparse
import tomllib
from typing import Any
from pprint import pprint
from y2015.day01 import main as day201501
from y2015.day02 import main as day201502
from y2015.day03 import main as day201503
from y2019.day01 import main as day201901
from y2020.day01 import main as day202001


PUZZLES = {"2015:01": day201501, "2015:02": day201502, "2015:03": day201503, "2019:01": day201901, "2020:01": day202001}


def loadConfig() -> dict[str, Any]:
    with open("config.toml", "rb") as f:
        tomlData = tomllib.load(f)
        return tomlData


def prependZero(d: int) -> str:
    return f"0{d}" if d < 10 else f"{d}"


def main(args) -> None:
    if args.year is None or args.day is None:
        print("Requires year and day. Run -h for help")
        return None

    key = f"{args.year}:{prependZero(args.day)}"
    solver = PUZZLES.get(key, None)
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

import argparse
from y2015.day01 import main as day201501
from y2015.day02 import main as day201502

PUZZLES = {"2015:01": day201501, "2015:02": day201502}


def main(args) -> None:
    if args.year is None or args.day is None:
        print("Requires year and day. Run -h for help")
        return None

    def prependZero(d: int) -> str:
        return f"0{d}" if d < 10 else f"{d}"

    key = f"{args.year}:{prependZero(args.day)}"
    solver = PUZZLES.get(key, None)
    if solver is None:
        print(f"{key} not found")
        return None

    solver()


if __name__ == "__main__":
    parser = argparse.ArgumentParser(description="Process arguments.")
    parser.add_argument("-y", "--year", type=int, help="AOC Year")
    parser.add_argument("-d", "--day", type=int, help="AOC Day")
    args = parser.parse_args()
    main(args)

from aoc.core import solve, AocInput
from dataclasses import dataclass
from functools import cmp_to_key
from typing import Callable

type Pages = list[str]
type PageUpdates = list[Pages]
type PagePrecedenceRules = Callable[[str, str], int]


@dataclass(frozen=True, slots=True)
class SafetyManual:
    updates: PageUpdates
    precedence_rules: PagePrecedenceRules


def sleigh_launch_safety_manual(text: str) -> SafetyManual:
    parts = text.split("\n\n")
    ordering = set(parts[0].split("\n"))
    updates = [u.split(",") for u in parts[1].split("\n")]
    precedence_rules = lambda p1, p2: -1 if f"{p1}|{p2}" in ordering else 1
    return SafetyManual(updates, precedence_rules)


def elf_page_sorting(precedence_rules: PagePrecedenceRules, pages: Pages) -> bool:
    return pages == sorted(pages, key=cmp_to_key(precedence_rules))


def extract_middle_page(pages: Pages) -> int:
    return int(pages[len(pages) // 2])


def part1(input: AocInput) -> int:
    manual = sleigh_launch_safety_manual(input.text)
    return sum(
        extract_middle_page(p) for p in [p for p in manual.updates if elf_page_sorting(manual.precedence_rules, p)]
    )


def part2(input: AocInput) -> int:
    manual = sleigh_launch_safety_manual(input.text)
    return sum(
        extract_middle_page(p)
        for p in [
            sorted(p, key=cmp_to_key(manual.precedence_rules))
            for p in [p for p in manual.updates if elf_page_sorting(manual.precedence_rules, p) is False]
        ]
    )


def main() -> None:
    YEAR = "y2024"
    DAY = "Day05"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1, 7307, True)
    solve(YEAR, DAY, part2, 4713, True)

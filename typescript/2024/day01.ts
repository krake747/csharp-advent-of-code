const aoc = require("./../aoc");

interface AocInput {
    text: string;
    lines: string[];
}

function zip<T>(arr1: T[], arr2: T[]) {
    return arr1.map((element, index) => [element, arr2[index]]);
}

function instructions(lines: string[], col: number): number[] {
    return lines.map(line => parseInt(line.split("   ")[col])).toSorted();
}

function part1(input: AocInput): number {
    const left = instructions(input.lines, 0);
    const right = instructions(input.lines, 1);
    return zip(left, right).reduce((sum, [l, r]) => sum + Math.abs(l - r), 0);
}

function part2(input: AocInput): number {
    return 0;
}

async function main() {
    const test = await aoc.findAocInput("./2024/data/Day01_Test.txt");
    const real = await aoc.findAocInput("./2024/data/Day01.txt");
    console.log("Part 1:", part1(test), part1(real), "expected", 1660292);
    console.log("Part 2:", part2(test), part2(real), "expected", 22776016);
}

main().catch(err => console.error(err));

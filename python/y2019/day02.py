from aoc.core import solve, AocInput
from dataclasses import astuple, dataclass


@dataclass
class IntCodeMachine:
    memory: list[int]

    def setNoun(self, noun: int) -> None:
        self.memory[1] = noun

    def setVerb(self, verb: int) -> None:
        self.memory[2] = verb

    @staticmethod
    def init(input: list[str]) -> "IntCodeMachine":
        return IntCodeMachine(memory=list(map(int, input.split(","))))

    @staticmethod
    def run(icm: "IntCodeMachine", noun: int, verb: int) -> int:
        icm.setNoun(noun)
        icm.setVerb(verb)
        memory = icm.memory[:]
        for i in range(0, len(memory), 4):
            opcode = memory[i]
            fst = memory[memory[i + 1]]
            snd = memory[memory[i + 2]]
            match opcode:
                case 99:  # Exit
                    return memory[0]
                case 1:  # Addition
                    memory[memory[i + 3]] = fst + snd
                case 2:  # Multiplication
                    memory[memory[i + 3]] = fst * snd

        return memory[0]

    @staticmethod
    def gravityAssist(icm: "IntCodeMachine") -> int:
        for noun in range(100):
            for verb in range(100):
                output = IntCodeMachine.run(icm, noun, verb)
                if output == 19690720:
                    return 100 * noun + verb

        return output


def part1(input: AocInput) -> int:
    icm = IntCodeMachine.init(input.text)
    return IntCodeMachine.run(icm, 12, 2)


def part2(input: AocInput) -> int:
    icm = IntCodeMachine.init(input.text)
    return IntCodeMachine.gravityAssist(icm)


def main() -> None:
    YEAR = "y2019"
    DAY = "Day02"
    print(f"Running year {YEAR.replace('y', '')} day {DAY.replace('Day', '')}")
    solve(YEAR, DAY, part1, skipTest=True)
    solve(YEAR, DAY, part2, skipTest=True)

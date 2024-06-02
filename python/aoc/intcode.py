from dataclasses import dataclass
from functools import partial
from typing import TypeAlias

Memory: TypeAlias = list[int]
Id: TypeAlias = int | None
Opcode: TypeAlias = int
Mode: TypeAlias = int


@dataclass
class IntCodeMachine:
    memory: Memory

    @staticmethod
    def init(input: list[str]) -> "IntCodeMachine":
        return IntCodeMachine(memory=list(map(int, input.split(","))))

    @staticmethod
    def noun(memory: Memory, noun: int) -> None:
        memory[1] = noun

    @staticmethod
    def verb(memory: Memory, verb: int) -> None:
        memory[2] = verb

    @staticmethod
    def opcode(memory: Memory, i: int) -> Opcode:
        return memory[i] % 100  # Last 2 digits

    @staticmethod
    def arg1(memory: Memory, i: int) -> int:
        mode = 1 if memory[i] >= 100 and ((memory[i] % 1000 - memory[i] % 100) == 100) else 0
        return memory[memory[i + 1]] if mode == 0 else memory[i + 1]

    @staticmethod
    def arg2(memory: Memory, i: int) -> int:
        mode = 1 if memory[i] >= 100 and ((memory[i] % 10000 - memory[i] % 1000) == 1000) else 0
        return memory[memory[i + 2]] if mode == 0 else memory[i + 2]

    @staticmethod
    def run(icm: "IntCodeMachine", noun: int | None = None, verb: int | None = None, input: Id = None) -> int:
        memory = icm.memory[:]

        if noun is not None:
            IntCodeMachine.noun(memory, noun)
        if verb is not None:
            IntCodeMachine.verb(memory, verb)

        address = partial(lambda m, i: m[i], memory)
        opcode = partial(IntCodeMachine.opcode, memory)
        arg1 = partial(IntCodeMachine.arg1, memory)
        arg2 = partial(IntCodeMachine.arg2, memory)
        output = []
        i = 0
        while i < len(memory):
            match opcode(i):
                case 1:  # Addition
                    memory[address(i + 3)] = arg1(i) + arg2(i)
                    i += 4
                case 2:  # Multiplication
                    memory[address(i + 3)] = arg1(i) * arg2(i)
                    i += 4
                case 3:  # Input
                    memory[address(i + 3)] = input
                    i += 2
                case 4:  # Output
                    output.append(memory[address(i + 1)])
                    i += 2
                case 5:  # Jump-If-True
                    if arg1(i) != 0:
                        i = arg2(i)
                        continue
                    i += 3
                case 6:  # Jump-If-False
                    if arg1(i) == 0:
                        i = arg2(i)
                        continue
                    i += 3
                case 7:  # Less Than
                    memory[address(i + 3)] = 1 if arg1(i) < arg2(i) else 0
                    i += 4
                case 8:  # Equals
                    memory[address(i + 3)] = 1 if arg1(i) == arg2(i) else 0
                    i += 4
                case 99:  # Exit
                    break
                case _:
                    raise Exception(f"invalid opcode {opcode}")

        return output[-1] if input else memory[0]

    @staticmethod
    def gravityAssist(icm: "IntCodeMachine", nouns=100, verbs=100) -> int:
        return next(
            100 * n + v for v in range(nouns) for n in range(verbs) if IntCodeMachine.run(icm, n, v) == 19690720
        )

    @staticmethod
    def thermalEnvironmentSupervisionTerminal(icm: "IntCodeMachine", id: Id) -> int:
        return IntCodeMachine.run(icm, input=id)

from dataclasses import dataclass


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
    def run(icm: "IntCodeMachine", noun: int | None = None, verb: int | None = None, input: int | None = None) -> int:
        if noun is not None:
            icm.setNoun(noun)
        if verb is not None:
            icm.setVerb(verb)

        output = [0]
        memory = icm.memory[:]
        i = 0
        while i < len(memory):
            opcode = memory[i] % 100  # last two digits
            fstMode = 0  # Mode: Position = 0, Immediate = 1
            sndMode = 0
            if memory[i] >= 100:
                if (memory[i] % 1000 - memory[i] % 100) == 100:
                    fstMode = 1
                if (memory[i] % 10000 - memory[i] % 1000) == 1000:
                    sndMode = 1

            match opcode:
                case 1:  # Addition
                    fst = memory[i + 1]
                    if fstMode == 0:
                        fst = memory[fst]

                    snd = memory[i + 2]
                    if sndMode == 0:
                        snd = memory[snd]

                    memory[memory[i + 3]] = fst + snd
                    i += 4
                case 2:  # Multiplication
                    fst = memory[i + 1]
                    if fstMode == 0:
                        fst = memory[fst]

                    snd = memory[i + 2]
                    if sndMode == 0:
                        snd = memory[snd]

                    memory[memory[i + 3]] = fst * snd
                    i += 4
                case 3:  # Input
                    memory[memory[i + 1]] = input
                    i += 2
                case 4:  # Output
                    output.append(memory[memory[i + 1]])
                    i += 2
                case 5:  # Jump-If-True
                    fst = memory[i + 1]
                    if fstMode == 0:
                        fst = memory[fst]

                    snd = memory[i + 2]
                    if sndMode == 0:
                        snd = memory[snd]

                    if fst != 0:
                        i = snd
                        continue

                    i += 3
                case 6:  # Jump-If-False
                    fst = memory[i + 1]
                    if fstMode == 0:
                        fst = memory[fst]

                    snd = memory[i + 2]
                    if sndMode == 0:
                        snd = memory[snd]

                    if fst == 0:
                        i = snd
                        continue

                    i += 3
                case 7:  # Less Than
                    fst = memory[i + 1]
                    if fstMode == 0:
                        fst = memory[fst]

                    snd = memory[i + 2]
                    if sndMode == 0:
                        snd = memory[snd]

                    memory[memory[i + 3]] = 1 if fst < snd else 0
                    i += 4
                case 8:  # Equals
                    fst = memory[i + 1]
                    if fstMode == 0:
                        fst = memory[fst]

                    snd = memory[i + 2]
                    if sndMode == 0:
                        snd = memory[snd]

                    memory[memory[i + 3]] = 1 if fst == snd else 0
                    i += 4
                case 99:  # Exit
                    break
                case _:
                    raise Exception(f"invalid opcode {opcode}")

        return output[-1] if input else memory[0]

    @staticmethod
    def gravityAssist(icm: "IntCodeMachine") -> int:
        for noun in range(100):
            for verb in range(100):
                output = IntCodeMachine.run(icm, noun, verb)
                if output == 19690720:
                    return 100 * noun + verb

        return output

    @staticmethod
    def thermalEnvironmentSupervisionTerminal(icm: "IntCodeMachine", id: int) -> int:
        return IntCodeMachine.run(icm, input=id)

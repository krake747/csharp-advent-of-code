from dataclasses import dataclass

@dataclass
class AocInput:
    text: str
    lines: list[str]

def getAocInput(path: str) -> AocInput:
    with open(path, 'r') as f:
        text = f.read()
        lines = f.readlines()
        aocInput = AocInput(text, lines)
        
    return aocInput
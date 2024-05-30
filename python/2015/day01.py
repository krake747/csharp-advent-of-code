import os
from aoc.core import getAocInput, AocInput    

def goUpOrDownOneFloor(c: str) -> int:
    return 1 if c == '(' else - 1

def part1(input: AocInput) -> int:           
    return sum(list(map(goUpOrDownOneFloor, input.text)))

def part2(input: AocInput) -> int:
    floors = []
    res = list(map(goUpOrDownOneFloor, input.text))
    for floor in res:
        lastFloorLevel = floors[-1] if len(floors) > 0 else 0
        updatedFloor = lastFloorLevel + floor
        floors.append(updatedFloor)
                    
    return floors.index(-1) + 1

def main() -> None:
    TEST_FILE = os.path.join('data', 'Day01_Test.txt')
    REAL_FILE = os.path.join('data', 'Day01.txt')

    testInput = getAocInput(TEST_FILE)
    realInput = getAocInput(REAL_FILE)

    t1x, t1, p1 = -1, part1(testInput), part1(realInput)
    t2x, t2, p2 = 5, part2(testInput), part2(realInput)
    
    print(f"Test Part 1: Expected {t1x} vs Actual {t1}")
    print(f"Real Part 1: Actual {p1}")
    
    print(f"Test Part 2: Expected {t2x} vs Actual {t2}")
    print(f"Real Part 2: Actual {p2}")
    
    
if __name__ == '__main__':
    main()

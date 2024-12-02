package day01

import (
	"aoc"
	"fmt"
	"math"
	"sort"
	"strconv"
	"strings"
)

func Part1(input *aoc.AocInput) int {
	lines := input.Lines
	left := instructions(lines, 0)
	right := instructions(lines, 1)

	sum := 0
	for i := 0; i < len(left); i++ {
		sum += int(math.Abs(float64(left[i] - right[i])))
	}

	return sum
}

func Part2(input *aoc.AocInput) int {
	lines := input.Lines
	left := instructions(lines, 0)
	right := instructions(lines, 1)
	counts := countOccurrences(right)

	sum := 0
	for _, id := range left {
		count := counts[id]
		sum += count * id
	}

	return sum
}

func instructions(lines []string, col int) []int {
	var result []int
	for _, line := range lines {
		nums := strings.Fields(line)
		if len(nums) > col {
			result = append(result, parseInt(nums[col]))
		}
	}

	sort.Ints(result)
	return result
}

func countOccurrences(nums []int) map[int]int {
	counts := make(map[int]int)
	for _, num := range nums {
		counts[num]++
	}

	return counts
}

func parseInt(s string) int {
	val, err := strconv.Atoi(s)
	if err != nil {
		fmt.Println("Error converting string to int:", err)
	}
	return val
}

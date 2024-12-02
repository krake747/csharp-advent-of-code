package day01_test

import (
	day01 "2024"
	"aoc"
	"fmt"
	"testing"
)

func TestPart1(t *testing.T) {
	tests := []struct {
		name  string
		input string
		want  int
	}{
		{"Test Day: 1, Part 1", "data/Day01_Test.txt", 11},
		{"Real Day: 1, Part 1", "data/Day01.txt", 1660292},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			input, err := aoc.FindAocInput(tt.input)
			if err != nil {
				t.Fatalf("Error loading input: %v", err)
			}

			got := day01.Part1(input)
			fmt.Printf("%s: want = %v, got = %v\n", tt.name, tt.want, got)
			if tt.want != got {
				t.Errorf("unexpected result for Part 1: want %v, got %v", tt.want, got)
			}
		})
	}
}

func TestPart2(t *testing.T) {
	tests := []struct {
		name  string
		input string
		want  int
	}{
		{"Test Day: 1, Part 2", "data/Day01_Test.txt", 31},
		{"Real Day: 1, Part 2", "data/Day01.txt", 22776016},
	}

	for _, tt := range tests {
		t.Run(tt.name, func(t *testing.T) {
			input, err := aoc.FindAocInput(tt.input)
			if err != nil {
				t.Fatalf("Error loading input: %v", err)
			}

			got := day01.Part2(input)
			fmt.Printf("%s: want = %v, got = %v\n", tt.name, tt.want, got)
			if tt.want != got {
				t.Errorf("unexpected result for Part 1: want %v, got %v", tt.want, got)
			}
		})
	}
}

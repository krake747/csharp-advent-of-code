package aoc

import (
	"bufio"
	"fmt"
	"os"
	"strings"
)

type AocInput struct {
	Text  string
	Lines []string
}

func openFile(filePath string) (*os.File, error) {
	file, err := os.Open(filePath)
	if err != nil {
		return nil, fmt.Errorf("unable to open file: %v", err)
	}
	return file, nil
}

func readFileLines(file *os.File) ([]string, string, error) {
	var lines []string
	var sb strings.Builder
	scanner := bufio.NewScanner(file)
	for scanner.Scan() {
		line := scanner.Text()
		lines = append(lines, line)
		sb.WriteString(line + "\n")
	}

	if err := scanner.Err(); err != nil {
		return nil, "", fmt.Errorf("unable to read file: %v", err)
	}

	return lines, sb.String(), nil
}

func FindAocInput(filePath string) (*AocInput, error) {
	file, err := openFile(filePath)
	if err != nil {
		return nil, err
	}
	defer file.Close()

	lines, text, err := readFileLines(file)
	if err != nil {
		return nil, err
	}

	return &AocInput{
		Text:  text,
		Lines: lines,
	}, nil
}

import * as fs from "fs/promises";
import * as path from "path";

interface AocInput {
    text: string;
    lines: string[];
}

const findAocInput = async (filePath: string): Promise<AocInput | null> => {
    const fullPath = path.resolve(filePath);
    try {
        const text = await fs.readFile(fullPath, "utf-8");
        let lines = text.split("\n").map(line => line.replace(/\r/g, ""));
        if (lines[lines.length - 1] === "") {
            lines = lines.slice(0, -1);
        }
        return <AocInput>{ text, lines };
    } catch (error) {
        console.error(`Unable to read file at ${filePath}: ${error}`);
        return null;
    }
};

// Export only the function using CommonJS
module.exports = {
    findAocInput
};

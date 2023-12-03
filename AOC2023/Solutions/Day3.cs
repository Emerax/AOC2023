namespace AOC2023.Solutions {
    internal class Day3(string inputFilePath) : BaseSolution(inputFilePath) {
        protected override string PartOne() {
            string[] lines = InputReaderUtil.RawLines(inputFilePath);
            int sum = 0;
            for(int lineIndex = 0; lineIndex < lines.Length; lineIndex++) {
                string line = lines[lineIndex];
                string currentNumber = string.Empty;
                bool isPartNumber = false;
                int number;

                for(int symbolIndex = 0; symbolIndex < line.Length; symbolIndex++) {
                    char c = line[symbolIndex];

                    if(!char.IsDigit(c)) {
                        if(isPartNumber && int.TryParse(currentNumber, out number)) {
                            sum += number;
                        }

                        currentNumber = string.Empty;
                        isPartNumber = false;
                    }

                    if(char.IsDigit(c)) {
                        currentNumber += c;

                        if(!isPartNumber) {
                            for(int x = -1; x <= 1; x++) {
                                for(int y = -1; y <= 1; y++) {
                                    if(x == 0 && y == 0) {
                                        continue;
                                    }

                                    int xIndex = symbolIndex + x;
                                    int yIndex = lineIndex + y;

                                    if(xIndex < 0 || xIndex >= line.Length) {
                                        continue;
                                    }

                                    if(yIndex < 0 || yIndex >= lines.Length) {
                                        continue;
                                    }

                                    char neighbour = lines[yIndex][xIndex];
                                    if(!char.IsDigit(neighbour) && neighbour != '.') {
                                        isPartNumber = true;
                                    }
                                }
                            }
                        }
                    }
                }

                if(isPartNumber && int.TryParse(currentNumber, out number)) {
                    sum += number;
                }
            }

            return sum.ToString();
        }

        protected override string PartTwo() {
            string[] lines = InputReaderUtil.RawLines(inputFilePath);
            int sum = 0;
            Dictionary<string, List<int>> gearPartNumbers = [];
            for(int lineIndex = 0; lineIndex < lines.Length; lineIndex++) {
                string line = lines[lineIndex];
                string currentNumber = string.Empty;
                List<string> adjacentGears = [];
                int number;

                for(int symbolIndex = 0; symbolIndex < line.Length; symbolIndex++) {
                    char c = line[symbolIndex];

                    if(!char.IsDigit(c)) {
                        if(adjacentGears.Count > 0 && int.TryParse(currentNumber, out number)) {
                            foreach(string gearIndex in adjacentGears) {
                                if(gearPartNumbers.TryGetValue(gearIndex, out List<int>? partsList)) {
                                    partsList.Add(number);
                                }
                                else {
                                    gearPartNumbers[gearIndex] = [];
                                    gearPartNumbers[gearIndex].Add(number);
                                }
                            }
                        }

                        currentNumber = string.Empty;
                        adjacentGears.Clear();
                    }

                    if(char.IsDigit(c)) {
                        currentNumber += c;

                        for(int x = -1; x <= 1; x++) {
                            for(int y = -1; y <= 1; y++) {
                                if(x == 0 && y == 0) {
                                    continue;
                                }

                                int xIndex = symbolIndex + x;
                                int yIndex = lineIndex + y;

                                if(xIndex < 0 || xIndex >= line.Length) {
                                    continue;
                                }

                                if(yIndex < 0 || yIndex >= lines.Length) {
                                    continue;
                                }

                                char neighbour = lines[yIndex][xIndex];
                                if(neighbour == '*') {
                                    adjacentGears.Add($"{yIndex}-{xIndex}");
                                }
                            }
                        }
                    }
                }

                if(adjacentGears.Count > 0 && int.TryParse(currentNumber, out number)) {
                    foreach(string gearIndex in adjacentGears) {
                        if(gearPartNumbers.TryGetValue(gearIndex, out List<int>? partsList)) {
                            partsList.Add(number);
                        }
                        else {
                            gearPartNumbers[gearIndex] = [];
                            gearPartNumbers[gearIndex].Add(number);
                        }
                    }
                }
            }

            foreach(string gearID in gearPartNumbers.Keys) {
                List<int> parts = gearPartNumbers[gearID].Distinct().ToList();

                if(parts.Count == 2) {
                    sum += parts[0] * parts[1];
                }
            }

            return sum.ToString();
        }
    }
}

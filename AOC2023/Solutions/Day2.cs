namespace AOC2023.Solutions {
    internal class Day2(string inputFilePath) : BaseSolution(inputFilePath) {
        protected override string PartOne() {
            return InputReaderUtil.RawLines(inputFilePath)
                .Where(game => game[(game.IndexOf(": ") + 2)..]
                    .Split("; ")
                    .Select(draw => draw.Split(", ")
                        .Select<string, (int Red, int Green, int Blue)>(entry => {
                            string[] data = entry.Split(" ");
                            return (data[1] == "red" ? int.Parse(data[0]) : 0, data[1] == "green" ? int.Parse(data[0]) : 0, data[1] == "blue" ? int.Parse(data[0]) : 0);
                        })
                        .Aggregate((t1, t2) => (t1.Red + t2.Red, t1.Green + t2.Green, t1.Blue + t2.Blue))
                    )
                    .All(t => t.Red <= 12 && t.Green <= 13 && t.Blue <= 14)
                )
                .Select(game => int.Parse(game
                    .Split(" ")[1]
                    .Replace(":", ""))
                )
                .Sum()
                .ToString();
        }

        protected override string PartTwo() {
            return InputReaderUtil.RawLines(inputFilePath)
                .Select(game => game[(game.IndexOf(": ") + 2)..]
                    .Split("; ")
                    .Select(draw => draw.Split(", ")
                        .Select<string, (int Red, int Green, int Blue)>(entry => {
                            string[] data = entry.Split(" ");
                            return (data[1] == "red" ? int.Parse(data[0]) : 0, data[1] == "green" ? int.Parse(data[0]) : 0, data[1] == "blue" ? int.Parse(data[0]) : 0);
                        })
                        .Aggregate((t1, t2) => (t1.Red + t2.Red, t1.Green + t2.Green, t1.Blue + t2.Blue))
                    )
                    .Aggregate((t1, t2) => (Math.Max(t1.Red, t2.Red), Math.Max(t1.Green, t2.Green), Math.Max(t1.Blue, t2.Blue)))
                )
                .Select(minCubes => minCubes.Red * minCubes.Green * minCubes.Blue)
                .Sum()
                .ToString();
        }
    }
}

using AOC2023.Solutions;

namespace AOC2023 {
    public class Program {
        private static readonly Dictionary<string, BaseSolution> solutions = new() {
            ["1"] = new Day1("day1.txt"),
            ["2"] = new Day2("day2.txt"),
            ["3"] = new Day3("day3.txt"),
            ["4"] = new Day4("day4.txt"),
            ["5"] = new Day5("day5.txt"),
            ["6"] = new Day6("day6.txt"),
            ["7"] = new Day7("day7.txt"),
            ["8"] = new Day8("day8.txt"),
            ["9"] = new Day9("day9.txt"),
            ["10"] = new Day10("day10.txt"),
            ["11"] = new Day11("day11.txt"),
            ["12"] = new Day12("day12.txt"),
            ["13"] = new Day13("day13.txt"),
            ["14"] = new Day14("day14.txt"),
            ["15"] = new Day15("day15.txt"),
            ["16"] = new Day16("day16.txt"),
            ["17"] = new Day17("day17.txt"),
            ["18"] = new Day18("day18.txt"),
            ["19"] = new Day19("day19.txt"),
            ["20"] = new Day20("day20.txt"),
            ["21"] = new Day21("day21.txt"),
            ["22"] = new Day22("day22.txt"),
            ["23"] = new Day23("day23.txt"),
            ["24"] = new Day24("day24.txt"),
            ["25"] = new Day25("day25.txt"),
        };

        public static void Main() {
            Console.WriteLine("Input [day] and [part] (1|2) to run corresponding solution. Input \"exit\" to exit.");
            while(true) {
                string raw = Console.ReadLine() ?? "";
                if(raw.Equals("exit", StringComparison.CurrentCultureIgnoreCase)) {
                    return;
                }

                string[] parameters = raw.Split(" ");
                if(parameters.Length >= 2) {
                    string day = parameters[0];
                    string part = parameters[1];

                    if(solutions.TryGetValue(day, out BaseSolution? solution)) {
                        switch(part) {
                            case "1":
                                solution.SolvePart1();
                                break;
                            case "2":
                                solution.SolvePart2();
                                break;
                            default:
                                Console.WriteLine($"Unknown part \"{part}\"");
                                break;
                        }
                    }
                    else {
                        Console.WriteLine($"No solution exists for day {day}");
                    }
                }

                Console.WriteLine("");
            }
        }
    }
}
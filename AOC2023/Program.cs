using AOC2023.Day1;

namespace AOC2023 {
    public class Program {
        private static readonly Dictionary<string, BaseSolution> solutions = new() {
            ["1"] = new DayOne("day1.txt")
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
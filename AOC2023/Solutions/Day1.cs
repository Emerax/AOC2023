namespace AOC2023.Solutions {
    public class Day1(string inputFilePath) : BaseSolution(inputFilePath) {

        protected override string PartOne() {
            return InputReaderUtil.RawLines(inputFilePath).Select(l => int.Parse($"{l.First(c => char.IsDigit(c))}{l.Last(c => char.IsDigit(c))}")).Sum().ToString();
        }

        protected override string PartTwo() {
            return InputReaderUtil.RawLines(inputFilePath).Select(l => l.Select((c, i) =>
                char.IsDigit(c) ? c.ToString() :
                    l[i..].StartsWith("one") ? "1" :
                        l[i..].StartsWith("two") ? "2" :
                            l[i..].StartsWith("three") ? "3" :
                                l[i..].StartsWith("four") ? "4" :
                                    l[i..].StartsWith("five") ? "5" :
                                        l[i..].StartsWith("six") ? "6" :
                                            l[i..].StartsWith("seven") ? "7" :
                                                l[i..].StartsWith("eight") ? "8" :
                                                    l[i..].StartsWith("nine") ? "9" : string.Empty
                ).Aggregate((s1, s2) => $"{s1}{s2}")).Select(l => int.Parse($"{l.First(c => char.IsDigit(c))}{l.Last(c => char.IsDigit(c))}")).Sum().ToString() ?? "Failed I guess";
        }
    }
}

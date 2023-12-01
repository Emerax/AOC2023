namespace AOC2023 {
    public class InputReaderUtil {
        private static string RelativeInputPath => $"{Directory.GetCurrentDirectory()}/Inputs";

        public static void ProcessInput(string inputFilePath, Action<string> lineProcessAction) {
            string[] lines = File.ReadAllLines($"{RelativeInputPath}/{inputFilePath}");
            foreach(string line in lines) {
                lineProcessAction(line);
            }
        }

        public static string[] RawLines(string inputFilePath) {
            return File.ReadAllLines($"{RelativeInputPath}/{inputFilePath}");
        }

        public static string RawText(string inputFilePath) {
            return File.ReadAllText($"{RelativeInputPath}/{inputFilePath}");
        }
    }
}
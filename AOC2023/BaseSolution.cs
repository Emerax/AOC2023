using System.Diagnostics;

namespace AOC2023 {
    public abstract class BaseSolution {
        protected string inputFilePath;

        protected BaseSolution(string inputFilePath) {
            this.inputFilePath = inputFilePath;
        }

        public void SolvePart1() {
            string result = PartOne();
            Console.WriteLine(result);
            SetClipboard(result);
        }

        protected abstract string PartOne();

        public void SolvePart2() {
            string result = PartTwo();
            Console.WriteLine(result);
            SetClipboard(result);
        }
        protected abstract string PartTwo();

        private static void SetClipboard(string value) {
            ArgumentNullException.ThrowIfNull(value);

            Process clipboardExecutable = new() {
                StartInfo = new ProcessStartInfo {
                    RedirectStandardInput = true,
                    FileName = @"clip",
                }
            };

            clipboardExecutable.Start();
            clipboardExecutable.StandardInput.Write(value);
            clipboardExecutable.StandardInput.Close();

            return;
        }

    }

}
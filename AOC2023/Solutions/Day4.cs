namespace AOC2023.Solutions {
    internal class Day4(string inputFilePath) : BaseSolution(inputFilePath) {
        protected override string PartOne() {
            return InputReaderUtil.RawLines(inputFilePath)
                .Select(card => card[(card.IndexOf(':') + 2)..])
                .Select(card => card.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .Select(card => (split: card.ToList().IndexOf("|"), numbers: card))
                .Select(card => (winning: card.numbers.Take(card.split), haves: card.numbers.Skip(card.split + 1)))
                .Select(card => card.haves.Intersect(card.winning))
                .Select(card => card.Count())
                .Select(wins => wins < 1 ? 0 : Math.Pow(2, wins - 1))
                .Sum()
                .ToString();
        }

        protected override string PartTwo() {
            List<int> cardScores = InputReaderUtil.RawLines(inputFilePath)
                .Select(card => card[(card.IndexOf(':') + 2)..])
                .Select(card => card.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .Select(card => (split: card.ToList().IndexOf("|"), numbers: card))
                .Select(card => (winning: card.numbers.Take(card.split), haves: card.numbers.Skip(card.split + 1)))
                .Select(card => card.haves.Intersect(card.winning))
                .Select(card => card.Count())
                .ToList();

            List<int> cards = Enumerable.Repeat(1, cardScores.Count).ToList();

            for(int cardNumber = 0; cardNumber < cards.Count; ++cardNumber) {
                int copies = cards[cardNumber];
                int score = cardScores[cardNumber];

                for(int i = cardNumber + 1; i <= cardNumber + score; ++i) {
                    cards[i] += copies;
                }
            }

            return cards
                .Sum()
                .ToString();
        }
    }
}

namespace Hangman
{
    public class Word
    {
        public string Content { get; set; }
        public int Size { get; set; }
        public Word(string content)
        {
            Content = content;
            Size = Content.Length;
        }
    }

    public class HangmanGame
    {
        public string Content { get; set; }
        public HangmanGame(string content) => this.Content = content;

        internal void Run(Word word, int hmLevel)
        {
            int cnt = 1;
            Console.WriteLine($"Current word is: {word.Content.ToLower()}");
            Word found = new Word(new string('_', word.Size));
            Console.WriteLine("\nFound result: " + found.Content);

            while (cnt <= hmLevel)
            {
                Console.Write($"\n\nPlease enter your {cnt} guest: ");
                ConsoleKeyInfo input = Console.ReadKey();

                if (!char.IsLetter(input.KeyChar)) continue;

                // count how many letter input in the word
                int repeatLetterCnt = word.Content.Count(x => x == input.KeyChar);
                Console.WriteLine($"\nThere is {repeatLetterCnt} letter {input.KeyChar}.");

                // find and replace the corresponding position
                char[] foundArray = found.Content.ToCharArray();
                for (int i = 0; i < word.Size; i++)
                {
                    if (word.Content[i] == input.KeyChar)
                    {
                        foundArray[i] = word.Content[i];
                    }
                }
                found.Content = new string(foundArray);

                Console.Write($"Current result: {found.Content}");

                if (word.Content.Equals(found.Content))
                {
                    Console.WriteLine("\nCongratulation! You WON!!!");
                    break;
                }

                cnt++;
            }

            Console.WriteLine($"You LOST!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== HANGMAN ===");
            List<Word> words = new List<Word>()
            {
                new Word("Hello"),
                new Word("Bird"),
                new Word("Sky"),
                new Word("Red"),
                new Word("Brown"),
                new Word("Play"),
                new Word("Communication"),
                new Word("Apple"),
            };

            // create a random word from a list
            Random random = new Random();
            Word word = words.ElementAt<Word>(random.Next(words.Count));

            // start to guest
            HangmanGame game = new HangmanGame(word.Content);
            game.Run(word, 5);

        }
    }
}

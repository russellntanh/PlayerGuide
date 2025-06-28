namespace TheCard
{
    // List of color
    enum COLOR { Red, Green, Blue, Yellow }

    // List of rank
    enum RANK { One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10, Dollar, Percent, Caret, Ampersand }

    // Create a card class
    class Card
    {
        public COLOR Color { get; set; }
        public RANK Rank { get; set; }
        public Card(COLOR c, RANK r)
        {
            Color = c;
            Rank = r;
        }

        // check number card
        public string GetCardType()
        {
            return (int)Rank <= 10 ? "Number" : "Symbol";
        }

        // get card type
        public string CardNumberOrSymbol()
        {
            return (int)Rank switch
            {
                <= 10 => "Number",
                > 10 => "Symbol",
            };
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== The Card ===");
            var colorSize = Enum.GetValues(typeof(COLOR)).Length;
            var rankSize = Enum.GetValues(typeof(RANK)).Length;

            int cnt = 0;
            foreach (COLOR color in Enum.GetValues(typeof(COLOR)))
            {
                foreach (RANK rank in Enum.GetValues(typeof(RANK)))
                {
                    Card card = new Card(color, rank);
                    Console.WriteLine(++cnt + ": The " + color.ToString() + " " + rank.ToString() + ": " + card.CardNumberOrSymbol());
                }
            }
        }
    }


}

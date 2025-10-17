namespace Advanced_PatternMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PATTERN MATCHING");
            
            RPSGame game = new RPSGame();
            game.Start();


            //Console.WriteLine("Please enter a number(Exit by 0): ");

            //try
            //{
            //    while (true)
            //    {
            //        if(!int.TryParse(Console.ReadLine(), out int result))
            //        {
            //            Console.WriteLine("Please enter a number!!!");
            //            continue;
            //        }
            //        if (result == 0) break;

            //        Console.Write(" is " + MonthOfTheYear(result));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }

        // Month of the Year
        public static string MonthOfTheYear(int month)
        {
            return month switch
            {
                1 => "Jannuary",
                2 => "February",
                3 => "March",
                4 => "April",
                5 => "May",
                6 => "June",
                7 => "July",
                8 => "August",
                9 => "September",
                10 => "October",
                11 => "November",
                12 => "December",
                _ => "Not a month"
            };
        }
    }

    public enum RPS
    {
        Rock,
        Paper,
        Scissor
    }

    public class Player
    {
        private static Random random = new Random();
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name, int score)
        {
            Name = name;
            Score = score;
        }

        public RPS Play()
        {
            return (RPS)random.Next(0, 3);
        }
    }

    public class RPSGame
    {
        Player player1 = new Player("Russell", 0);
        Player player2 = new Player("Tom", 0);

        public void Start()
        {
            int rounds = 5;

            for (int i = 0; i < rounds; i++)
            {
                RPS p1 = player1.Play();
                RPS p2 = player2.Play();
                Console.WriteLine($"{player1.Name} plays {p1}, {player2.Name} plays {p2}");
                switch((p1, p2))
                { 
                    case (RPS.Rock, RPS.Scissor):
                    case (RPS.Scissor, RPS.Paper):
                    case (RPS.Paper, RPS.Rock):
                        player1.Score++;
                        Console.WriteLine($"{player1.Name} wins this round.");
                        break;
                    case (RPS.Scissor, RPS.Rock):
                    case (RPS.Paper, RPS.Scissor):
                    case (RPS.Rock, RPS.Paper):
                        player2.Score++;
                        Console.WriteLine($"{player2.Name} wins this round.");
                        break;
                    default:
                        Console.WriteLine("It's a tie.");
                        break;
                }
            }

            Console.WriteLine($"Player1 is {player1.Name} and score is {player1.Score} \n Player2 is {player2.Name} and score is {player2.Score}");
        }
    }

}

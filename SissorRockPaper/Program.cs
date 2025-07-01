namespace SissorRockPaper
{
    //1. Create player class
    // - Constructor
    // - Property: Win/Lost, Draw
    // - Play method: Sissor, Rock, Paper
    // - Game rule
    //2. Create SRP Game class
    // - Know existing player
    // - Run method

    public enum SrpOption { Sissor, Rock, Paper }
    public enum WonLostDraw { Won, Lost, Draw }
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=== Sissor - Rock - Paper ===");

                Game game = new Game("Player1", "Player2");

                game.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class Game
    {
        Random random = new Random();

        List<Player> players;

        public Game(params string[] playerNames)
        {
            players = playerNames.Select(x => new Player(x)).ToList();
        }

        public void Run()
        {
            int cnt = 1;

            while (cnt <= 5)
            {
                cnt++;
                Console.WriteLine($"The {cnt} try: ");

                var allEnumValues = Enum.GetValues(typeof(SrpOption));

                players[0].SrpOption = (SrpOption)allEnumValues.GetValue(random.Next(allEnumValues.Length));
                players[1].SrpOption = (SrpOption)allEnumValues.GetValue(random.Next(allEnumValues.Length));

                Console.WriteLine($"Player1: {players[0].SrpOption}, Player2: {players[1].SrpOption}");
                JudgementRule(players[0], players[1]);

                DisplayResult();
            }
        }

        public void JudgementRule(Player p1, Player p2)
        {
            // check draw
            if (p1.SrpOption == p2.SrpOption)
            {
                p1.DrawCount += 1;
                p2.DrawCount += 1;
                return;
            }

            // pair of winning
            Dictionary<SrpOption, SrpOption> winningPairs = new Dictionary<SrpOption, SrpOption>
            {
                { SrpOption.Sissor, SrpOption.Paper }, // keo > bao
                { SrpOption.Paper, SrpOption.Rock}, // bao > bua
                { SrpOption.Rock, SrpOption.Sissor} // bua > keo
            };

            if (winningPairs.ContainsKey(p1.SrpOption) && winningPairs[p1.SrpOption] == p2.SrpOption)
            {
                p1.WonCount += 1;
                p2.LostCount += 1;
            }
            else
            {
                p1.LostCount += 1;
                p2.WonCount += 1;
            }
        }

        public void DisplayResult()
        {
            Console.WriteLine("=== Name === Won === Lost === Draw ===");
            foreach (var player in players)
            {
                Console.WriteLine($"   {player.Name}  :  {player.WonCount}   {player.LostCount}   {player.DrawCount}");
            }

            if (players[0].WonCount > players[1].WonCount)
                Console.WriteLine($"{players[0].Name} is WON");
            else if (players[0].WonCount < players[1].WonCount)
                Console.WriteLine($"{players[1].Name} is WON");
            else
                Console.WriteLine("The game is tie");
        }
    }

    public class Player
    {
        public string Name { get; set; }
        public SrpOption SrpOption { get; set; }
        public int WonCount { get; set; }
        public int LostCount { get; set; }
        public int DrawCount { get; set; }

        public Player(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("Player name can't be empty");
            Name = name;

        }
    }
}

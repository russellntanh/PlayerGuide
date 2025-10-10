using System.Drawing;

namespace Advanced_Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EVENT IN C#");

            //Ship ship = new Ship();
            //MessageManager showMess = new MessageManager(ship);
            //ship.Run();

            //Asteroid asteroid = new Asteroid();
            //SoundManager soundManager = new SoundManager(asteroid);
            //asteroid.Run();

            CharberryTree cherry = new CharberryTree();
            Notifier notifier = new Notifier(cherry);
            Harvester harvester = new Harvester(cherry);
            
            while(true)
            {
                cherry.MaybeGrow();
            }
        }
    }

    // publisher
    public class CharberryTree
    {
        private Random _random = new Random();
        public bool Ripe { get; set; }

        public event EventHandler? _fruitRipen;

        public void MaybeGrow()
        {
            var ranNum = _random.Next();
            if (ranNum < 10 && !Ripe)
            {
                Console.WriteLine(ranNum);
                Ripe = true;
                _fruitRipen.Invoke(this, EventArgs.Empty);
            }
        }
    }

    // subscriber
    public class Notifier
    {
        public void OnCharryRipen(object sender, EventArgs e)
        {
            Console.WriteLine("To Notifier: A fruit is ripen now.");
        }

        public Notifier(CharberryTree cherryTree)
        {
            cherryTree._fruitRipen += OnCharryRipen;
        }

    }

    public class Harvester
    {
        public void OnCharryRipen(object sender, EventArgs e)
        {
            Console.WriteLine("To Harvester: A fruit is ripen now.");
        }

        public Harvester(CharberryTree cherryTree)
        {
            cherryTree._fruitRipen += OnCharryRipen;
        }
    }



    // publisher
    public class Ship
    {
        public event Action? ShowMessage; // event without param
        public event Action<Point>? ShowMessageLocation; // event with param

        Random random = new Random();
        public Point location { get;set;} = new Point();

        public void Run()
        {
            for (int i = 10; i >= 0; i--)
            {
                location = new Point(random.Next(100), random.Next(100));
                Console.WriteLine($"Ship's current location ({location.X}, {location.Y}) Blood amount is: " + i);

                if (i == 0)
                {
                    ShowMessage?.Invoke();
                    ShowMessageLocation?.Invoke(location);
                }
            }
        }
    }

    // subscriber
    public class MessageManager
    {
        private void OnShowMessage()
        {
            ShowMessage("Ship is exploded");
        }

        private void OnShowMessageLocation(Point location)
        {
            ShowMessage($"Ship is exploded at location is ({location.X}, {location.Y})");
        }

        public MessageManager(Ship ship)
        {
            ship.ShowMessage += OnShowMessage;
            ship.ShowMessageLocation += OnShowMessageLocation;
        }

        public void ShowMessage(string messsage)
        {
            Console.WriteLine(messsage);
        }
    }

    // Using EventHandler
    public class AsteroidExplodedLocation : EventArgs
    {
        public Point Location { get;set;}
        public AsteroidExplodedLocation(Point location)
        {
            Location = location;
        }
    }
    public class Asteroid
    {
        public event EventHandler? ShipExploded; // EventHandler no param
        public event EventHandler<AsteroidExplodedLocation>? AsteroidExplodedLocation; // with param

        Point location { get; set; } = new Point();

        Random random = new Random();

        public void Run()
        {
            for(int i = 10; i >=0; i--)
            {
                location = new Point(random.Next(100), random.Next(100));
                Console.WriteLine($"Asteroid's location: ({location.X}, {location.Y})");

                if (i == 0)
                {
                    ShipExploded?.Invoke(this, EventArgs.Empty);
                    AsteroidExplodedLocation?.Invoke(this, new AsteroidExplodedLocation(location));
                }
            }
        }
    }

    // subscriber
    public class SoundManager
    {
        private void OnPlaySound(object sender, EventArgs e) // no param
        {
            Console.WriteLine($"Buummmm");
        }

        private void OnPlaySoundLocation(object sender, AsteroidExplodedLocation e) // with param
        {
            Console.WriteLine($"Buummmm at location: ({e.Location.X}, {e.Location.Y})");
        }

        public SoundManager(Asteroid asteroid)
        {
            asteroid.ShipExploded += OnPlaySound;
            asteroid.AsteroidExplodedLocation += OnPlaySoundLocation;
        }
    }
}

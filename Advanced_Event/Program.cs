using System.Drawing;

namespace Advanced_Event
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("EVENT IN C#");

            Ship ship = new Ship();
            MessageManager showMess = new MessageManager(ship);
            ship.Run();

        }
    }

    // publisher
    public class Ship
    {
        public event Action ShowMessage; // event without param
        public event Action<Point> ShowMessageLocation; // event with param

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
                    ShowMessage.Invoke();
                    ShowMessageLocation.Invoke(location);
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
}

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

        Random random = new Random();
        public Point location { get;set;} = new Point();

        public void Run()
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.WriteLine($"Ship's Blood amount is: " + i);

                if (i == 0)
                {
                    ShowMessage.Invoke();
                }
            }
        }
    }

    // subscriber
    public class MessageManager
    {
        private void OnShowMessage() => ShowMessage("Exploded");

        public MessageManager(Ship ship)
        {
            ship.ShowMessage += OnShowMessage;
        }

        public void ShowMessage(string messsage)
        {
            Console.WriteLine("Exploded.");
        }

    }
}

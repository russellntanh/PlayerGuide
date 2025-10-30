using System.Diagnostics;
using System.Threading;

namespace Advanced_Thread
{
    public class Program
    {

        public static void Main()
        {
            Console.WriteLine("Hello, worl");

            Random random = new Random();
            var luckyNumberGuess = new LuckyNumberGuess();

            // Thread to generate random number
            Thread threadGenerator = new Thread(() =>
            {
                while (true)
                {
                    int number = random.Next(0, 10);
                    luckyNumberGuess.Update(number);
                    Console.WriteLine($"Generated number: {number}.");
                    Thread.Sleep(1000);
                }
            });
            //threadGenerator.IsBackground = true;


            // Thread to guess number
            Thread threadCheckRepeat = new Thread(() => 
            {
                Console.WriteLine("Press Enter to check repeated numbers");
                Console.ReadLine();
                while (true)
                {
                    if (luckyNumberGuess.IsRepeat())
                    {
                        Console.WriteLine($"Correct: {luckyNumberGuess.Previous}, {luckyNumberGuess.Current}");
                    }
                    else
                    {
                        Console.WriteLine($"Not correct, 2 most recent numbers are different");
                    }
                    //Console.WriteLine("Press Enter to continue checking.");
                }
            });
            //threadCheckRepeat.IsBackground = true;

            threadGenerator.Start();
            threadCheckRepeat.Start();

            Console.WriteLine("Press Ctr + C to exit.");
            Thread.Sleep(Timeout.Infinite); // Hoặc dùng Console.ReadLine() nếu muốn

        }
    }

    //#region Test even odd number thread
    //        GetEvenOddNumbers getEvenOddNumbers = new GetEvenOddNumbers();
    //    Thread eventThread = new Thread(getEvenOddNumbers.GetEvenNumbers);
    //        eventThread.Name = "Even Thread";
    //        Thread oddThread = new Thread(getEvenOddNumbers.GetOddNumbers);
    //oddThread.Name = "Odd Thread";
            
    //        eventThread.Start();
    //        oddThread.Start();
            
    //        eventThread.Join();
    //        oddThread.Join();
    //        #endregion

    //        #region Test thread with lock
    //        SharedData sharedData = new SharedData();
    //Thread thread = new Thread(sharedData.Increate); // sub thread
    //thread.Start();
    //        thread.Join();
    //        Console.WriteLine("Sub thread: " + sharedData.Count);

    //        sharedData.Increate();
    //        Console.WriteLine("Main thread: " +sharedData.Count);
    //        #endregion
    public class SharedData
    {
        private readonly object _lockNumber = new();
        private int _count = 0;
        public int Count
        {
            get 
            {
                lock(_lockNumber)
                {
                    return _count;
                }
            }
        }

        public void Increate()
        {
            lock (_lockNumber)
            {
                _count++;
            }
        }

    }
}

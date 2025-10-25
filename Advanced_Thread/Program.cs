using System.Diagnostics;
using System.Threading;

namespace Advanced_Thread
{
    public class ThreadWithLock
    {
        public static void Main()
        {
            GetEvenOddNumbers getEvenOddNumbers = new GetEvenOddNumbers();
            Thread eventThread = new Thread(getEvenOddNumbers.GetEvenNumbers);
            eventThread.Name = "Even Thread";
            Thread oddThread = new Thread(getEvenOddNumbers.GetOddNumbers);
            oddThread.Name = "Odd Thread";
            
            eventThread.Start();
            oddThread.Start();
            
            eventThread.Join();
            oddThread.Join();

            // Test thread with lock
            SharedData sharedData = new SharedData();
            Thread thread = new Thread(sharedData.Increate); // sub thread
            thread.Start();
            thread.Join();
            Console.WriteLine("Sub thread: " + sharedData.Count);

            sharedData.Increate();
            Console.WriteLine("Main thread: " +sharedData.Count);
        }
    }

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

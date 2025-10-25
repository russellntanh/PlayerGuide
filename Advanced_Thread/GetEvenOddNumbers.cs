using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Thread
{
    public class GetEvenOddNumbers
    {
        public void GetEvenNumbers()
        {
            Console.WriteLine($"Even thread is running");
            for (int i = 0; i <= 10; i++)
            {
                if (i%2 == 0) Console.WriteLine("Even: " + i);
            }
            Console.WriteLine($"Even thread is finished");
        }

        public void GetOddNumbers()
        {
            Console.WriteLine($"Odd thread is running");
            for (int i = 0; i<=10; i++)
            {
                if (i%2 == 1) Console.WriteLine("Odd: " + i);
                if (i == 5)
                {
                    Console.WriteLine("Odd thread is exiting early");
                    return;
                }
            }
            Console.WriteLine($"Odd thread is finished");
        }
    }
}

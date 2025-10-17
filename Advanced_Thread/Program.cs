namespace Advanced_Thread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Started.");

            // ParameterStart : parameterless method
            Thread thread1 = new Thread(CountToHundred); 
            thread1.Start();

            // ParameterizedThreadStart : parameter method need to use lambda expression
            Thread thread2 = new Thread(() => CountToHundred(30)); 
            thread2.Start();

            Console.WriteLine("Main Thread Done.");
        }

        // method with parameters
        static void CountToHundred(int n) 
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i+1);
            }
        }

        // method without parameters
        static void CountToHundred()
        {
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine(i + 1);
            }
        }
    }
}

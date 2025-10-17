namespace Advanced_Thread
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Started.");

            // ParameterStart : parameterless method
            //Thread thread1 = new Thread(CountToHundred);
            //thread1.Start();

            // ParameterizedThreadStart : parameter method need to use lambda expression
            //Thread thread2 = new Thread(() => CountToHundred(30));
            //thread2.Start();

            Calculation calc = new Calculation() { x = 10, y = 20 };
            Thread thread3 = new Thread(AddNumbers);
            thread3.Start(calc);
            thread3.Join(); 
            Console.WriteLine($"Result: {calc.result}");


            Console.WriteLine("Main Thread Done.");
        }

        static void AddNumbers(object? data)
        {
            if (data == null) return;
            Calculation calc = (Calculation)data;
            calc.result = calc.x + calc.y;
        }

        // method with parameters
        static void CountToHundred(int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(i + 1);
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

    public class Calculation
    {
        public int x { get; set; }
        public int y { get; set; }
        public int result { get; set; }
    }
}

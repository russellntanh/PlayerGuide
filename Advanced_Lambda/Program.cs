namespace Advanced_Lambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lambda Express!");

            int x = 10;

            Console.WriteLine(IsNegative(x));
            Console.WriteLine(IsNegativeLambda(x));

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 14, 50, -20, -5 };

            int CountThreshold = numbers.Count(x => x < 0);

            Console.WriteLine(CountNegative(numbers, IsNegativeLambda));

            Action[] actionsTodo = new Action[10];

            for (int index = 0; index < 10; index++)
            {
                int t = index;
                Console.WriteLine(t);
                actionsTodo[index] = () => Console.WriteLine(index);
            }
        }


        static int CountNegative(int[] numbers, Func<int, bool> predicate)
        {
            int count = 0; 
            foreach (int x in numbers)
            {
                if (predicate(x)) count++;
            }
            return count;
        }

        // normal style
        static bool IsNegative(int x) 
        { 
            return x < 0; 
        }

        // lambda expression
        static bool IsNegativeLambda(int x) => x < 0;

        
    }
}

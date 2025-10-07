namespace Advanced_Delegate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Delegate Sample Code");
            int[] numbers = { 1, 2, 3, 4, 5 };

            // Use static method
            int[] numbers2 = Calculation.AddOneToArray(numbers);
            int[] numbers3 = Calculation.RemoveOneFromArray(numbers);
            int[] numbers4 = Calculation.DoubleToArray(numbers);
            int[] numbers5 = Calculation.SquereToArray(numbers);

            // Use delegate method
            CalculateByDelegate calc = new CalculateByDelegate();
            int[] result1 = calc.ChangeArrayElement(numbers, calc.AddOne);
            int[] result2 = calc.ChangeArrayElement(numbers, calc.RemoveOne);
            int[] result3 = calc.ChangeArrayElement(numbers, calc.Double);
            int[] result4 = calc.ChangeArrayElement(numbers, calc.Square);

        }
    }

    public class CalculateByDelegate
    {
        public delegate int CalculationDelegate(int number);
        
        public int[] ChangeArrayElement(int[] array, CalculationDelegate operation)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = operation(array[i]);
            }
            return result;
        }

        public int AddOne(int number) => number + 1;
        public int RemoveOne(int number) => number - 1;
        public int Square(int number) => number * number;
        public int Double(int number) => number * 2;
    }

    public static class Calculation
    {

        // method to increase each element of array one unit
        public static int[] AddOneToArray(int[] array)
        {
            int[] result = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i] + 1;
            }
            return result;
        }

        // method to decrease each element of array one unit
        public static int[] RemoveOneFromArray(int[] array)
        {
            int[] result = new int[array.Length];
            for(int i = 0;i < array.Length;i++)
            {
                result[i] = array[i] - 1;
            }
            return result;
        }

        // method to square each element of array 
        public static int[] SquereToArray(int[] array)
        {
            int[] result = new int[(int)array.Length];
            for(int i = 0; i < array.Length;i++)
            {
                result[i] = (int)array[i] * array[i];
            }
            return result;
        }

        // method to double each element of array 
        public static int[] DoubleToArray(int[] array)
        {
            int[] result = new int[(int)array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = (int)array[i] * 2;
            }
            return result;
        }

        // method to get square root of each element of array
        public static double[] SquareRoot(double[] array)
        {
            double[] result = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = Math.Sqrt(array[i]);
            }
            return result;
        }
    }
}

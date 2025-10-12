namespace Advanced_PatternMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PATTERN MATCHING");
            
            Console.WriteLine("Please enter a number(Exit by 0): ");

            try
            {
                while (true)
                {
                    if(!int.TryParse(Console.ReadLine(), out int result))
                    {
                        Console.WriteLine("Please enter a number!!!");
                        continue;
                    }
                    if (result == 0) break;

                    Console.Write(" is " + MonthOfTheYear(result));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }

        // Month of the Year
        public static string MonthOfTheYear(int month)
        {
            return month switch
            {
                1 => "Jannuary",
                2 => "February",
                3 => "March",
                4 => "April",
                5 => "May",
                6 => "June",
                7 => "July",
                8 => "August",
                9 => "September",
                10 => "October",
                11 => "November",
                12 => "December",
                _ => "Not a month"
            };
        }
    }


}

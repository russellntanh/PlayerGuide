using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Thread
{
    public class LuckyNumberGuess
    {
        public int Previous { get; set; }
        public int Current { get; set; }

        private readonly Random _random = new Random();

        private readonly object _lock = new object();

        public LuckyNumberGuess()
        {
            Previous = -1;
            Current = -1;
        }

        public void Update(int number)
        {
            lock(_lock)
            {
                Previous = Current;
                Current = number;
            }
        }

        public bool IsRepeat()
        {
            lock (_lock)
            {
                return Previous != -1 && Current != -1 && Previous == Current;
            }
        }

        public int GetCurrent()
        {
            lock (_lock)
            {
                return Current;
            }
        }
    }
}

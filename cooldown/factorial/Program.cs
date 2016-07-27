using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine(factorial.fac(15));
            var x = String.Empty;
            do
            {
                x = Console.ReadLine();
                var errorCounter = Regex.Matches(x, @"[a-zA-Z]").Count;
                if (errorCounter == 0)
                 Console.WriteLine(factorial.fac(Convert.ToInt32(x))); 
        
            } while (x != "quit");
        }
    }

    class factorial
    {
        public factorial()
        {
            // Console.WriteLine()
        }

        public static int fac(int x)
        {
            if (x == 1)
                return x;

            return x * fac (x - 1);
        }
    }
}

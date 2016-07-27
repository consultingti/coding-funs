using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace prime
{
    class Program
    {

        static void Main(string[] args)
        {
            var x = String.Empty;

            do
            {
                x = Console.ReadLine();
                var errorCounter = Regex.Matches(x, @"[a-zA-Z]").Count;
                if (errorCounter == 0)
                {
                    var calculo = Enumerable.Range(1, Convert.ToInt32(x)).Where(y => y <= Math.Sqrt(Convert.ToInt32(x))).Where(z => Convert.ToInt32(x) % z == 0).Count();
                    if (calculo >= 2)
                        Console.WriteLine("not prime");
                    else
                        Console.WriteLine("prime");
                }
                
            } while (x!="quit");
        }
    }
}

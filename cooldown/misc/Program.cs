using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace misc
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable test = new Hashtable();
            test.Add(99, "como?");
            test.Add(102, "hola");
            test.Add(89, "juliana");
            test.Add(101, "que haces");
            


            foreach (var x in test.Keys)
            { Console.WriteLine(x);
                Console.WriteLine(test[x]);
            }
            Console.ReadLine();

            Dictionary<int, string> test2 = new Dictionary<int, string>();
            test2.Add(102, "hola");
            test2.Add(89, "juliana");
            test2.Add(101, "que haces");

            foreach (var x in test2)
            {
                Console.WriteLine(x.Key);
                Console.WriteLine(x.Value);
            }

            Console.ReadLine();
        }
    }
}

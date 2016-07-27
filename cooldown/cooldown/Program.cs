using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cooldown
{
    class Program
    {
        static void Main(string[] args)
        {
            cooldown c = new cooldown();
            foreach (var x in c.tasks)
            {
               
                Console.WriteLine(x.Value);

            }

            c.TimeSpend(0);
            Console.WriteLine(c.TimeTakes);
            Console.ReadLine();
        }
    }


    class cooldown
    {
        public int TimeTakes = 0; //the cooldown time
        public Dictionary<int, int> tasks = null;
        int coold;


        public cooldown()
        {
           
            TimeTakes = 1; // total
            coold= 3; //cooldown globally for tasks
            tasks = new Dictionary<int, int>();

            Add(5); //adding some tasks with random duration values
        }

        public void Add(int n)
        {
            Random rnd = new Random();
            
            for (int x = 1; x <= n; x++)
            {
                tasks.Add(x, rnd.Next(1, 3));
            }
        }

        public void TimeSpend(int n)
        {
            if (n > 0) coold = n;

            // time spent to run all tasks, considering the cooldown
            foreach (var x in tasks)
            {
                TimeTakes += x.Value + coold;
            }
        }

    }

}

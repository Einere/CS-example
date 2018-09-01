using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beakjoon
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            input = Int32.Parse(Console.ReadLine());

            Queue<int> Q = new Queue<int>();
            for (int i = 1; i <= input; i++)
            {
                Q.Enqueue(i);
            }

            try
            {
                while (Q.Peek() >= 0)
                {
                    Console.WriteLine("{0}", Q.Peek());
                    Q.Dequeue();
                    int tmp = Q.Dequeue();
                    Q.Enqueue(tmp);
                }
            }
            catch(Exception e)
            {
                return ;
            }
            
        }
    }
}

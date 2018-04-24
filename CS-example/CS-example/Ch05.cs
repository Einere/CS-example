using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CS_example
{
    class Ch05
    {
        private int limit = 0;

        public void main()
        {
            Ch05 t = new Ch05();

            ThreadStart ts1 = new ThreadStart(t.Say);
            ThreadStart ts2 = new ThreadStart(t.Say);

            Thread thread1 = new Thread(ts1);
            Thread thread2 = new Thread(ts2);

            Console.WriteLine("\nthread " + Thread.CurrentThread.ManagedThreadId + " is main thread.");

            thread1.Start();
            thread2.Start();
        }

        public void Say()
        {
            int hash = Thread.CurrentThread.ManagedThreadId;
            int count = 0;

            lock (this)
            {
                while(count < 5)
                {
                    Console.WriteLine("Thread " + hash + ": " + limit++);
                    count++;
                    Thread.Sleep(10);
                }
            }
        }
    }
}

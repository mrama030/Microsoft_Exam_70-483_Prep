using System;
using System.Threading;

// https://www.youtube.com/watch?v=RhLLxew4-TY

namespace Listing_1_1
{
    // LISTING 1-1 Creating a thread with the Thread class
    public static class Program
    {
        public static void Main(string[] args)
        {
            Thread secondaryThread = new Thread(new ThreadStart(ThreadMethod));
            secondaryThread.Start();

            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main Thread - Processing Line {0}", i);
            }

            // Wait until secondary thread has completed processing.
            secondaryThread.Join();

            Console.WriteLine("Main Thread - Complete");
        }

        public static void ThreadMethod()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Secondary Thread - Processing Line {0}", i);
                // Do not use the entire thread time slice assigned by the OS. 
                // Give up the remaining time to another thread immediately.
                Thread.Sleep(0);
            }

            Console.WriteLine("Secondary Thread - Complete");
        }
    }
}

using System;
using System.Threading;

namespace Listing_1_2
{
    // LISTING 1-2 Using a background thread
    public static class Program
    {
        public static void Main(string[] args)
        {
            Thread secondaryThread = new Thread(new ThreadStart(BackgroundMethod));
            secondaryThread.IsBackground = true; // Thread keeps running even if Main thread terminates.
            secondaryThread.Start();
            // Note: Main thread (console) terminates here, so you will not see anything printed by the background thread.

            // If secondary thread is specified as foreground (which is the default value), 
            // then the main thread does not terminate until all threads are completed.
        }

        public static void BackgroundMethod()
        {
            for (int x = 0; x < 10; x++)
            {
                Console.WriteLine("Background Thread - Processing Line {0}", x);
                Thread.Sleep(1000); // Sleep for 1s.
            }
        }
    }
}

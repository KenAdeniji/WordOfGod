using System;
using System.Threading;

class ThreadSample
{
    static AutoResetEvent autoEvent;

    static void DoWork()
    {
        Console.WriteLine("   worker thread started, now waiting on event...");
        autoEvent.WaitOne();
        Console.WriteLine("   worker thread reactivated, now exiting...");
    }

    static void Main()
    {
        autoEvent = new AutoResetEvent(false);

        Console.WriteLine("main thread starting worker thread...");
        Thread t = new Thread(DoWork);
        t.Start();

        Console.WriteLine("main thrad sleeping for 1 second...");
        Thread.Sleep(1000);

        Console.WriteLine("main thread signaling worker thread...");
        autoEvent.Set();
    }
}
using System.Diagnostics;

namespace MH06;

internal class Program
{
    static void Main(string[] args)
    {
        int counter = 0;
        int max = int.MaxValue;
        object locker = new object();
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Thread thread1 = new Thread(() =>
        {
            for (int i = 0; i < max; i++)
            {
                Monitor.Enter(locker);
                try
                {
                    counter++;
                }
                finally
                {
                    Monitor.Exit(locker);
                }
            }
        });
        Thread thread2 = new Thread(() =>
        {
            for (int i = 0; i < max; i++)
            {
                Monitor.Enter(locker);
                try
                {
                    counter--;
                }
                finally
                {
                    Monitor.Exit(locker);
                }
            }
        });
        thread1.Start(); thread2.Start();
        thread1.Join(); thread2.Join();
        sw.Stop();
        Console.WriteLine($"Time: {sw.Elapsed}  Counter: {counter}");
    }
}

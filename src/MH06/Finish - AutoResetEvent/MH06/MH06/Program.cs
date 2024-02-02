using System.Diagnostics;

namespace MH06;

internal class Program
{
    static void Main(string[] args)
    {
        int counter = 0;
        int max = int.MaxValue/4;
        AutoResetEvent autoResetEvent = new AutoResetEvent(true);
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Thread thread1 = new Thread(() =>
        {
            for (int i = 0; i < max; i++)
            {
                autoResetEvent.WaitOne();
                counter++;
                autoResetEvent.Set();
            }
        });
        Thread thread2 = new Thread(() =>
        {
            for (int i = 0; i < max; i++)
            {
                autoResetEvent.WaitOne();
                counter--;
                autoResetEvent.Set();
            }
        });
        thread1.Start(); thread2.Start();
        thread1.Join(); thread2.Join();
        sw.Stop();
        Console.WriteLine($"Time: {sw.Elapsed}  Counter: {counter}");
    }
}

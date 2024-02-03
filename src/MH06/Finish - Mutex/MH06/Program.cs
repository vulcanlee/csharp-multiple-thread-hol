using System.Diagnostics;

namespace MH06;

internal class Program
{
    static void Main(string[] args)
    {
        int counter = 0;
        int max = int.MaxValue;  // int.MaxValue = 2147483647
        //int max = 999999;  // int.MaxValue = 2147483647
        Mutex mutex = new Mutex();
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Thread thread1 = new Thread(() =>
        {
            for (int i = 0; i < max; i++)
            {
                if(i % 20_0000 == 0)
                {
                    Console.WriteLine($"Thread1: {i} - {max-i}");
                }
                mutex.WaitOne();
                counter++;
                //Console.Write($"{counter} ");
                mutex.ReleaseMutex();
            }
        });
        Thread thread2 = new Thread(() =>
        {
            for (int i = 0; i < max; i++)
            {
                mutex.WaitOne();
                counter--;
                //Console.Write($"{counter} ");
                mutex.ReleaseMutex();
            }
        });
        thread1.Start(); thread2.Start();
        thread1.Join(); thread2.Join();
        sw.Stop();
        Console.WriteLine($"Time: {sw.Elapsed}  Counter: {counter}");
    }
}

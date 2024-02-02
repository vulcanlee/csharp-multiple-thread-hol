using System.Diagnostics;

namespace MH06;

internal class Program
{
    static void Main(string[] args)
    {
        int counter = 0;
        int max = 999999;  // int.MaxValue = 2147483647
        Semaphore semaphore = new Semaphore(1, 1); // 1 : 初始許可數  1 : 最大許可數
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Thread thread1 = new Thread(() =>
        {
            for (int i = 0; i < max; i++)
            {
                semaphore.WaitOne();
                counter++;
                semaphore.Release();
            }
        });
        Thread thread2 = new Thread(() =>
        {
            for (int i = 0; i < max; i++)
            {
                semaphore.WaitOne();
                counter--;
                semaphore.Release();
            }
        });
        thread1.Start(); thread2.Start();
        thread1.Join(); thread2.Join();
        sw.Stop();
        Console.WriteLine($"Time: {sw.Elapsed}  Counter: {counter}");
    }
}

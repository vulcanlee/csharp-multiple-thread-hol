using System.Diagnostics;

namespace MH06;

internal class Program
{
    static void Main(string[] args)
    {
        int counter = 0;
        int max = 999999;  // int.MaxValue = 2147483647

        // false : 非訊號狀態  true : 訊號狀態
        AutoResetEvent autoResetEvent = new AutoResetEvent(true);
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Thread thread1 = new Thread(() =>
        {
            for (int i = 0; i < max; i++)
            {
                autoResetEvent.WaitOne(); // 等待信號
                counter++;
                autoResetEvent.Set(); // 發送信號
            }
        });
        Thread thread2 = new Thread(() =>
        {
            for (int i = 0; i < max; i++)
            {
                autoResetEvent.WaitOne(); // 等待信號
                counter--;
                autoResetEvent.Set(); // 發送信號
            }
        });
        thread1.Start(); thread2.Start();
        thread1.Join(); thread2.Join();
        sw.Stop();
        Console.WriteLine($"Time: {sw.Elapsed}  Counter: {counter}");
    }
}

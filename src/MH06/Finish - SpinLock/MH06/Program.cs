using System.Diagnostics;

namespace MH06;

internal class Program
{
    static void Main(string[] args)
    {
        int counter = 0;
        int max = int.MaxValue;
        SpinLock spinLock = new SpinLock();
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Thread thread1 = new Thread(() =>
        {
            bool gotLock = false;
            for (int i = 0; i < max; i++)
            {
                gotLock = false;
                spinLock.Enter(ref gotLock);
                counter++;
                spinLock.Exit();
            }
        });
        Thread thread2 = new Thread(() =>
        {
            bool gotLock = false;
            for (int i = 0; i < max; i++)
            {
                gotLock = false;
                spinLock.Enter(ref gotLock);
                counter--;
                spinLock.Exit();
            }
        });
        thread1.Start(); thread2.Start();
        thread1.Join(); thread2.Join();
        sw.Stop();
        Console.WriteLine($"Time: {sw.Elapsed}  Counter: {counter}");
    }
}

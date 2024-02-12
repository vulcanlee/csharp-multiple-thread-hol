using System.Diagnostics;

namespace MH01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            #region 輸出 100 次的 World!
            Thread thread1 = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    System.Console.Write("World! ");
                    Thread.Sleep(50);
                }
            });
            thread1.Start();
            #endregion

            #region 輸出 100 次的 Hello
            Thread thread2 = new Thread(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    System.Console.Write("Hello ");
                    Thread.Sleep(50);
                }
            });
            thread2.Start();
            #endregion

            thread1.Join();
            thread2.Join();
            sw.Stop();
            System.Console.WriteLine("\n\nElapsed={0}", sw.Elapsed);
        }
    }
}

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
            for (int i = 0; i < 100; i++)
            {
                System.Console.Write("Hello ");
                Thread.Sleep(50);
            }
            #endregion

            #region 輸出 100 次的 Hello
            for (int i = 0; i < 100; i++)
            {
                System.Console.Write("World! ");
                Thread.Sleep(50);
            }
            #endregion

            sw.Stop();
            System.Console.WriteLine("\n\nElapsed={0}", sw.Elapsed);
        }
    }
}

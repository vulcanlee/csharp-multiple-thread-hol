using System.Diagnostics;

namespace MH06;

internal class Program
{
    static void Main(string[] args)
    {
        int counter = 0;
        int max = int.MaxValue;
        Stopwatch sw = new Stopwatch();
        sw.Start();
        for (int i = 0; i < max; i++)
        {
            counter++;
        }
        for (int i = 0; i < max; i++)
        {
            counter--;
        }
        Console.WriteLine($"Time: {sw.Elapsed}  Counter: {counter}");
    }
}

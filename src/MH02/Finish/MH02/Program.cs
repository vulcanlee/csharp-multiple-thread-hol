using System.Diagnostics;

namespace MH02
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            IBreakfast breakfast = new Breakfast();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            await breakfast.MakeBreakfastAsync(eggs: 2, bacon: 3);

            stopwatch.Stop();
            Console.WriteLine($"總共花費了{stopwatch.ElapsedMilliseconds}毫秒");
        }
    }
}

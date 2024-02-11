using System.Diagnostics;

namespace MH09
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var gaussianBlur = new GaussianBlur();
            await gaussianBlur.ProcessAsync();
            stopwatch.Stop();
            Console.WriteLine($"花費時間: {stopwatch.ElapsedMilliseconds} ms");
        }
    }
}

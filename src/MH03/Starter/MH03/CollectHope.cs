using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH03
{
    public class CollectHope
    {
        List<string> hopes = new List<string>();
        Stopwatch stopwatch = new Stopwatch();

        public void AddHopes()
        {
            Enumerable.Range(0, 10000)
                .ToList()
                .ForEach(i =>
                {
                    hopes.Add($"{i} - {DateTime.Now}");
                });
        }

        public void CountHopes() => Console.WriteLine($"There are {hopes.Count} hopes.");

        public void Start() { stopwatch.Start(); }
        public void Stop() { stopwatch.Stop();}
        public void Reset() { stopwatch.Reset(); }
        public void Elapsed() => Console.WriteLine($"Elapsed time: {stopwatch.ElapsedMilliseconds} ms.");
    }
}

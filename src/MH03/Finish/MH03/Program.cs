using System.Collections.Concurrent;

namespace MH03
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CollectHope collectHope = new CollectHope();

            collectHope.Start();
            Task task1 = Task.Run(() => collectHope.AddHopes());
            Task task2 = Task.Run(() => collectHope.AddHopes());
            Task task3 = Task.Run(() => collectHope.AddHopes());

            await Task.WhenAll(task1, task2, task3);
            collectHope.Stop();

            collectHope.Elapsed();
            collectHope.CountHopes();
        }
    }
}

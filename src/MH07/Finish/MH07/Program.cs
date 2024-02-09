using System.Threading;

namespace MH07
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            CancellationTokenSource cts =
                new CancellationTokenSource(TimeSpan.FromSeconds(5));
            CancellationToken token = cts.Token;

            // 按下按鍵 Ctrl+C 取消非同步作業
            ThreadPool.QueueUserWorkItem(async (state) =>
            {
                Console.WriteLine("按下按鍵 Ctrl+C 取消非同步作業");
                Console.CancelKeyPress += (sender, e) =>
                {
                    e.Cancel = true;
                    cts.Cancel();
                };
            });

            try
            {
                AddingCalculator addingCalculator =
                    new AddingCalculator();
                string result = await addingCalculator
                    .Add(1, 2, 3000, token);
                Console.WriteLine(result);
            }
            catch (OperationCanceledException ex)
            {
                Console.WriteLine("非同步作業執行中被取消了");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

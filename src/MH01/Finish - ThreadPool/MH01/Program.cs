using System.Diagnostics;
using System.Threading.Tasks;

namespace MH01
{
    // 這個範例會示範如何使用 ThreadPool 來執行非同步工作
    internal class Program
    {
        static void Main(string[] args)
        {
            // WaitHandle 將等候共用資源獨佔存取權限的特定作業系統物件封裝起來
            WaitHandle[] waitHandles = new WaitHandle[]
            {
                // AutoResetEvent 代表執行緒同步處理事件會在發出訊號時，釋出一個等候執行緒之後，就自動重設。
                // 這個類別是一個簡單的狀態標記，用來通知等候執行緒，某個事件已經發生。
                // true 表示初始狀態設定為已收到信號，false 表示初始狀態設定為未收到信號
                new AutoResetEvent(false),
                new AutoResetEvent(false)
            };
            Stopwatch sw = new Stopwatch();
            sw.Start();

            #region 輸出 100 次的 World!
            ThreadPool.QueueUserWorkItem(x=>
            {
                AutoResetEvent are = (AutoResetEvent)x!;
                for (int i = 0; i < 100; i++)
                {
                    System.Console.Write("World! ");
                    Thread.Sleep(50);
                }
                // 設定 AutoResetEvent 來通知 WaitHandle.WaitAll() 方法
                are.Set();
            }, waitHandles[0]);
            #endregion

            #region 輸出 100 次的 Hello
            ThreadPool.QueueUserWorkItem(x =>
            {
                AutoResetEvent are = (AutoResetEvent)x!;
                for (int i = 0; i < 100; i++)
                {
                    System.Console.Write("Hello ");
                    Thread.Sleep(50);
                }
                // 設定 AutoResetEvent 來通知 WaitHandle.WaitAll() 方法
                are.Set();
            }, waitHandles[1]);
            #endregion

            // 等待兩個 AutoResetEvent 被設定
            WaitHandle.WaitAll(waitHandles);
            sw.Stop();
            System.Console.WriteLine("\n\nElapsed={0}", sw.Elapsed);
        }
    }
}

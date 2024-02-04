using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MH05
{
    public class MyService
    {
        public async Task<string> StartAsync()
        {
            int beforeAsyncThreadId = Environment.CurrentManagedThreadId;
            var task = GetAsync();
            var result = await task.ConfigureAwait(false);
            int afterAsyncThreadId = Environment.CurrentManagedThreadId;
            Debug.WriteLine($"[StartAsync] Before async: {beforeAsyncThreadId}, after async: {afterAsyncThreadId}");
            await Task.Delay(result / 20);
            return result.ToString() + $" {DateTime.Now}";
        }

        public async Task<int> GetAsync()
        {
            int beforeAsyncThreadId = Environment.CurrentManagedThreadId;
            var result = await new HttpClient()
                .GetStringAsync("https://www.google.com").ConfigureAwait(false);
            int afterAsyncThreadId = Environment.CurrentManagedThreadId;
            Debug.WriteLine($"[GetAsync] Before async: {beforeAsyncThreadId}, after async: {afterAsyncThreadId}");
            return result.Length;
        }
    }
}

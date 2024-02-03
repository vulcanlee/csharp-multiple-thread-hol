using System;
using System.Collections.Generic;
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
            var result = GetAsync().Result;
            await Task.Delay(result / 20);
            return result.ToString() + $" {DateTime.Now}";
        }

        public async Task<int> GetAsync()
        {
            var result = await new HttpClient()
                .GetStringAsync("https://www.google.com");
            return result.Length;
        }
    }
}

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
        public async Task StartAsync()
        {
            var result = GetAsync().Result;
            await Task.Delay(result / 20);
        }

        public async Task<int> GetAsync()
        {
            var result = await new HttpClient()
                .GetStringAsync("https://www.google.com");
            return result.Length;
        }
    }
}

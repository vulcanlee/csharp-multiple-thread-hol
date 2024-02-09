using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH07
{
    public class AddingCalculator
    {
        public async Task<string> Add(int value1, int value2, int elapsedTime)
        {
            string url = $"https://businessblazor.azurewebsites.net/api/RemoteService/" +
                $"Add/{value1}/{value2}/{elapsedTime}";
            HttpClient client = new HttpClient();
            string result = await client.GetStringAsync(url);
            return result;
        }
    }
}

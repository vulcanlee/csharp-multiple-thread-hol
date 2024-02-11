using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH08
{
    public class SalesReport
    {
        public async void GenerateReportAsync()
        {
            Console.WriteLine("產生銷售報表 ...");
            ReadDataAsync();
            Console.WriteLine("銷售報表產生完成 ...");
        }
        async Task ReadDataAsync()
        {
            string url = "http://www.mydomain.com/salesdata.csv";
            var client = new HttpClient();
            Console.WriteLine("讀取銷售數據 ...");
            var data = await client.GetStringAsync(url);
            Console.WriteLine("整理銷售數據 ...");
            await Task.Delay(2000);
            Console.WriteLine("銷售數據整理完成 ...");
        }
    }
}

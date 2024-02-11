using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MH08
{
    public class NewSalesReport
    {
        public async Task GenerateReportAsync()
        {
            Console.WriteLine("產生 新 銷售報表 ...");
            ReadDataAsync();
            Console.WriteLine("銷售 新 報表產生完成 ...");
        }
        async Task ReadDataAsync()
        {
            string url = "http://www.mydomain.com/salesdata.csv";
            var client = new HttpClient();
            Console.WriteLine("讀取 新 銷售數據 ...");
            var data = await client.GetStringAsync(url);
            Console.WriteLine("整理 新 銷售數據 ...");
            await Task.Delay(2000);
            Console.WriteLine("銷售 新 數據整理完成 ...");
        }
    }
}

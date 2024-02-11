namespace MH08;

public class SalesReport
{
    public async Task GenerateReportAsync()
    {
        Console.WriteLine("產生銷售報表 ...");
        Task task = ReadDataAsync();
        try
        {
            await task;
            Console.WriteLine("銷售報表產生完成 ...");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"SalesReport 發現例外異常 : {ex.Message}");
            throw;
        }
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

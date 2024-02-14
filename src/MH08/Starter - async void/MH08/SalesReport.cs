namespace MH08;

public class SalesReport
{
    public void GenerateReport()
    {
        Console.WriteLine("產生 新 銷售報表 ...");
        try
        {
            ReadDataAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.WriteLine("銷售 新 報表產生完成 ...");
    }
    async void ReadDataAsync()
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

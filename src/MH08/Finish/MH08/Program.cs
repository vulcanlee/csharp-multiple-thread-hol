namespace MH08;

public class Program
{
    static async Task Main(string[] args)
    {
        SalesReport salesReport = new();
        Task task = salesReport.GenerateReportAsync();
        try
        {
            await task;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Main 發現例外異常 : {ex.Message}");
        }
        //NewSalesReport newSalesReport = new();
        //newSalesReport.GenerateReportAsync();

        Console.WriteLine("Press any key to exit ...");
        Console.ReadKey();
    }
}

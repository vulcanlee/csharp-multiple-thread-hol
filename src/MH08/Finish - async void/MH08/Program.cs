namespace MH08;

public class Program
{
    static async Task Main(string[] args)
    {
        SalesReport salesReport = new();
        try
        {
            await salesReport.GenerateReportAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine("[Main]\n" + ex.Message);
        }

        Console.WriteLine("Press any key to exit ...");
        Console.ReadKey();
    }
}

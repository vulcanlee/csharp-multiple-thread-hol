namespace MH08;

public class Program
{
    static void Main(string[] args)
    {
        SalesReport salesReport = new();
        salesReport.GenerateReport();
        //NewSalesReport newSalesReport = new();
        //newSalesReport.GenerateReportAsync();

        Console.WriteLine("Press any key to exit ...");
        //Console.ReadKey();
    }
}

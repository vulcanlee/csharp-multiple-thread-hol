namespace MH08
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SalesReport salesReport = new();
            salesReport.GenerateReportAsync();
            NewSalesReport newSalesReport = new();
            newSalesReport.GenerateReportAsync();

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }
}

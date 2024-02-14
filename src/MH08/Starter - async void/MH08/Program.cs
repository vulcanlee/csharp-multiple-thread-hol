namespace MH08;

public class Program
{
    static void Main(string[] args)
    {
        SalesReport salesReport = new();
        salesReport.GenerateReport();

        Console.WriteLine("Press any key to exit ...");
        Console.ReadKey();
    }
}

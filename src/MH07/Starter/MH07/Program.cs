namespace MH07
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            AddingCalculator addingCalculator = new AddingCalculator();

            string result = await addingCalculator.Add(1, 2, 10000);
            Console.WriteLine(result);
        }
    }
}

namespace MH05.Components.Pages;

public class MyService
{
    public async Task<string> StartAsync()
    {
        var result = await GetAsync();
        await Task.Delay(result / 20);
        return result.ToString() + $" {DateTime.Now}";
    }

    public async Task<int> GetAsync()
    {
        var result = await new HttpClient()
            .GetStringAsync("https://www.google.com");
        return result.Length;
    }
}

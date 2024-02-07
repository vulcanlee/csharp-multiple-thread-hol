using System.Diagnostics;

namespace MH05.Components.Pages;

public class MyService
{
    public async Task<string> StartAsync()
    {
        int beforeAsyncThreadId = Environment.CurrentManagedThreadId;
        var task = GetAsync();
        var result = await task.ConfigureAwait(false);
        int afterAsyncThreadId = Environment.CurrentManagedThreadId;
        Console.WriteLine($"[StartAsync] Before async: {beforeAsyncThreadId}, after async: {afterAsyncThreadId}");
        await Task.Delay(result / 20);
        return result.ToString() + $" {DateTime.Now}";
    }

    public async Task<int> GetAsync()
    {
        int beforeAsyncThreadId = Environment.CurrentManagedThreadId;
        var result = await new HttpClient()
            .GetStringAsync("https://www.google.com").ConfigureAwait(false);
        int afterAsyncThreadId = Environment.CurrentManagedThreadId;
        Console.WriteLine($"[GetAsync] Before async: {beforeAsyncThreadId}, after async: {afterAsyncThreadId}");
        return result.Length;
    }
}

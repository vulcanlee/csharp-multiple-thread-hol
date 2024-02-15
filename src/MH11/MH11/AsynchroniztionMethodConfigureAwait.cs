namespace MH11;

public class AsynchroniztionMethodConfigureAwait
{
    public async Task Run()
    {
        await Task.Delay(3000).ConfigureAwait(false);
        //Task task = Task.Delay(3000);
        //ConfiguredTaskAwaitable awaitable = task.ConfigureAwait(false);
        //await awaitable;
    }
}

namespace MH11;

public class AsynchroniztionTask
{
    public Task Run()
    {
        return Task.Delay(3000);
        //Task task = Task.Delay(3000);
        //return task;
    }
}

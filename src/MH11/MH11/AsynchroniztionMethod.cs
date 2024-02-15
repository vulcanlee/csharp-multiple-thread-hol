using System.Threading.Tasks;

namespace MH11;

public class AsynchroniztionMethod
{
    public async Task Run()
    {
        await Task.Delay(3000);
    }
}

using System.Threading.Tasks;

namespace Bliss;

public class DagNodeExecutor : IDagNodeExecutor
{
    public async Task<int> ExecuteAsync(IDagNode unitOfExecution)
    {
        unitOfExecution.ExecuteAsync();
        await Task.Delay(1000); // Replace this with your actual implementation
        return 0; // Replace this with your actual implementation
    }
}

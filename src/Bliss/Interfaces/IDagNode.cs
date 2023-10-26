namespace Bliss;

/// <summary>
/// Executes a node in the graph.
/// </summary>
public interface IDagNode
{
    /// <returns> 0 if success, < 0 otherwise.</returns>
    Task<int> ExecuteAsync();
}
namespace Bliss
{

    /// <summary>
    /// Interface for the execution of a DAG.
    /// </summary>
    public interface IDagExecutor
    {
        /// <summary>
        /// Processes a Dag request and returns a response: success or failure.
        /// </summary>
        /// <param name="request">The request to be processed</param>
        /// <returns>The response.</returns>
        Task<RequestResponse> ProcessRequestAsync(DagRequest request);
    }
}
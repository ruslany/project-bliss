namespace Bliss;

public class DagResponse {

    bool Success { get; set; }

    string Output { get; set; }

    public DagResponse(bool success, string output)
    {
        Output = output;
    }
}
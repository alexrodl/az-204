using Microsoft.Azure.Functions.Worker;

namespace DurableImageProcessor_net8;

public class SaveMetadata
{
    [Function("SaveMetadata")]
    public void Run(
        [ActivityTrigger] string blobName)
    {
        Console.WriteLine($"Saving metadata for {blobName}");
    }
}
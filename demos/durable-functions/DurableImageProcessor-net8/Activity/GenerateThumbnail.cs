using Microsoft.Azure.Functions.Worker;

namespace DurableImageProcessor_net8;

public class GenerateThumbnail
{
    [Function("GenerateThumbnail")]
    public void Run([ActivityTrigger] string blobName)
    {
        Console.WriteLine($"Generating thumbnail for {blobName}");
    }
}
using Microsoft.Azure.Functions.Worker;

namespace DurableImageProcessor;

public class GenerateThumbnail
{
    [Function("GenerateThumbnail")]
    public void Run(
        [ActivityTrigger] string blobName)
    {
        Console.WriteLine(
            $"Generating thumbnail for {blobName}");
    }
}
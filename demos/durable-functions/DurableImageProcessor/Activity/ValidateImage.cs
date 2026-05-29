using Microsoft.Azure.Functions.Worker;

namespace DurableImageProcessor;

public class ValidateImage
{
    [Function("ValidateImage")]
    public void Run(
        [ActivityTrigger] string blobName)
    {
        Console.WriteLine(
            $"Validating {blobName}");
    }
}